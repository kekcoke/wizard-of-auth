using System.Security.Cryptography.X509Certificates;
using wizard_of_auth.Application.Certificates.Models;
using wizard_of_auth.Core.Entities;
using wizard_of_auth.Core.Entities.Certificates;
using wizard_of_auth.Core.Enums.Certificates;

namespace wizard_of_auth.Application.Interfaces;
/// <summary>
/// Manages cryptographic certificates for token signing and encryption.
/// Supports key rotation and JWKS (JSON Web Key Set) for OpenID Connect.
/// </summary>
public interface ICertificateService
{
    #region Certificate Retrieval
    
    /// <summary>
    /// Gets the current primary signing certificate
    /// </summary>
    Task<X509Certificate2> GetCurrentSigningCertificateAsync(
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets a certificate by Key ID (kid) for token validation
    /// </summary>
    Task<X509Certificate2?> GetCertificateByKeyIdAsync(
        string keyId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets all valid certificates for token validation (includes rotated keys in grace period)
    /// </summary>
    Task<IReadOnlyCollection<X509Certificate2>> GetValidationCertificatesAsync(
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets certificate for encryption (if supported)
    /// </summary>
    Task<X509Certificate2?> GetEncryptionCertificateAsync(
        CancellationToken ct = default);
    
    #endregion
    
    #region JWKS (JSON Web Key Set) - OpenID Connect
    
    /// <summary>
    /// Exports the public keys as JWKS (JSON Web Key Set) for OpenID Connect discovery
    /// </summary>
    Task<string> GetJwksAsync(CancellationToken ct = default);
    
    /// <summary>
    /// Gets a single JWK by Key ID
    /// </summary>
    Task<string?> GetJwkByKeyIdAsync(string keyId, CancellationToken ct = default);
    
    #endregion
    
    #region Key Rotation
    
    /// <summary>
    /// Initiates certificate rotation with configurable overlap period
    /// </summary>
    Task<Result<KeyRotationResult>> InitiateKeyRotationAsync(
        TimeSpan? overlapPeriod = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Completes key rotation, removing old certificates
    /// </summary>
    Task<Result<bool>> CompleteKeyRotationAsync(
        string rotationId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Cancels an in-progress key rotation
    /// </summary>
    Task<Result<bool>> CancelKeyRotationAsync(
        string rotationId,
        CancellationToken ct = default);
    
    #endregion
    
    #region Certificate Status & Monitoring
    
    /// <summary>
    /// Gets detailed status of all certificates
    /// </summary>
    Task<CertificateStatus> GetCertificateStatusAsync(
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets rotation schedule and history
    /// </summary>
    Task<IReadOnlyList<KeyRotationHistory>> GetRotationHistoryAsync(
        int count = 10,
        CancellationToken ct = default);
    
    /// <summary>
    /// Validates certificate health (expiration, revocation)
    /// </summary>
    Task<CertificateHealthResult> ValidateCertificateHealthAsync(
        CancellationToken ct = default);
    
    #endregion
    
    #region SAML Certificate Support
    
    /// <summary>
    /// Gets certificate for SAML assertion signing
    /// </summary>
    Task<X509Certificate2> GetSamlSigningCertificateAsync(
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets certificate for SAML message encryption
    /// </summary>
    Task<X509Certificate2?> GetSamlEncryptionCertificateAsync(
        CancellationToken ct = default);
    
    /// <summary>
    /// Exports SAML metadata descriptor with certificates
    /// </summary>
    Task<string> GetSamlMetadataAsync(
        string entityId,
        CancellationToken ct = default);
    
    #endregion
}