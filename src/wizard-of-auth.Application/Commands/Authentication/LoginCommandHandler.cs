using IdentityModel.OidcClient;
using MediatR;
using wizard_of_auth.Application.Authentication;
using wizard_of_auth.Core.Interfaces;

namespace wizard_of_auth.Application.Commands.Authentication;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    // private readonly IPasswordHashingService _passwordHasher;
    private readonly IAuditLogger _auditLogger;
    
    public LoginCommandHandler(
        IUserRepository userRepository,
        ITokenService tokenService,
        // IPasswordHashingService passwordHasher,
        IAuditLogger auditLogger)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        // _passwordHasher = passwordHasher;
        _auditLogger = auditLogger;
    }

    public async Task<LoginResult> Handle(LoginCommand request, CancellationToken ct)
    {
        var user = await _userRepository.GetEmailAsync(request.Email, ct);

        if (user == null ||
            !_passwordHasher.Verify(request.Password, user.PasswordHash))
        {
            await _auditLogger.LogFailedLoginAsync(request.Email);
            return new LoginResult(false, null, null, false, "Invalid credentials");
        }

        if (user.IsLocked)
        {
            return new LoginResult(false, null, null, false, "Account locked");
        }

        if (user.MfaEnabled && string.IsNullOrEmpty(request.MfaCode))
        {
            return new LoginResult(false, null, null, true, null);
        }

        user.RecordSuccessfulLogin();
        await _userRepository.UpdateAsync(user, ct);
        
        // Get tokens
        var accessToken = await _tokenService.GetType(user, null, new List<string>());
        var refreshToken = await _tokenService.GenerateRefreshTokenAsync(user, null);

        await _auditLogger.LogSuccessfulAsync(user.Id);

        return new LoginResult(true, accessToken, refreshToken, false, null);
    }
}

