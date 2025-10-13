using FluentValidation;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using wizard_of_auth.Core.Interfaces;
using wizard_of_auth.Infrastructure.Persistence;
using wizard_of_auth.Infrastructure.Protocols.OAuth2;
using wizard_of_auth.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// MediatR
builder.Services.AddMediatR(cfg 
    => cfg.RegisterServicesFromAssembly(typeof(ApplicationDbContext).Assembly));

// FluentValidation
builder.Services.AddValidatorsFromAssembly(typeof(ApplicationDbContext).Assembly);

// Services
// builder.Services.AddScoped<ITokenService, TokenService>();
// builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddScoped<IClientService, ClientService>();
// builder.Services.AddScoped<IAuditLogService, AuditLogService>();
// builder.Services.AddScoped<IIdentityProviderService, IdentityProviderService>();
// builder.Services.AddScoped<ITenantService, TenantService>();
// builder.Services.AddScoped<IEmailService, EmailService>();

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

// Protocol Handlers
builder.Services.AddScoped<OAuthHandler>();
// builder.Services.AddScoped<OidcConnectHandler>();
// builder.Services.AddScoped<SamlHandler>();

// Security
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("login", opt =>
    {
        opt.PermitLimit = 5;
        opt.Window = TimeSpan.FromMinutes(1);
    });
});

// Cahcing
// builder.Services.AddMemoryCache();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
    options.InstanceName = "wizard_of_auth";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.UseSecurityHeaders(); // Custom middleware
app.UseRateLimiter();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();