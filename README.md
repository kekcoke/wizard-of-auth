A production-ready, modular authentication server supporting OAuth 2.0, OpenID Connect, and SAML 2.0.

## Features

- 🔐 **Multiple Protocols**: OAuth 2.0, OIDC, SAML 2.0
- 🔌 **Pluggable Connectors**: LDAP, Azure AD, Google, Okta, and more
- 🛡️ **Enterprise Security**: MFA, anomaly detection, rate limiting
- 🏢 **Multi-Tenancy**: Full tenant isolation
- 📊 **Comprehensive Auditing**: Detailed security event logging
- 🚀 **High Performance**: Horizontal scaling, caching, optimized queries
- 🧪 **Extensive Testing**: Unit, integration, stress, and security tests

## Quick Start

### Prerequisites

- .NET 8 SDK
- Docker Desktop
- PostgreSQL 16+ (or use Docker)
- Redis (or use Docker)

### Setup

```bash
# Clone the repository
git clone https://github.com/kekcoke/wizard-of-auth.git
cd universal-auth-server

# Run setup script
pwsh ./scripts/setup-dev-environment.ps1

# Start the application
dotnet run --project src/wizard-of-auth.API
```

The server will be available at `https://localhost:5001`

### Using Docker

```bash
docker-compose up -d
```

## Configuration

See `appsettings.json` for full configuration options.

### Key Configuration Areas

- **Protocols**: Enable/disable OAuth2, OIDC, SAML
- **Connectors**: Configure identity providers
- **Security**: Password policies, MFA, rate limiting
- **Certificates**: Auto-generation and rotation settings

## Testing

```bash
# Run all tests
dotnet test

# Run specific test suites
dotnet test tests/wizard-of-auth.UnitTests
dotnet test tests/wizard-of-auth.IntegrationTests
dotnet test tests/wizard-of-auth.StressTests
dotnet test tests/wizard-of-auth.SecurityTests
```

## API Documentation

Once running, visit:
- Swagger UI: `https://localhost:5001/swagger`
- OpenID Discovery: `https://localhost:5001/.well-known/openid-configuration`

## Architecture

```
┌─────────────────────────────────────┐
│         API Gateway Layer           │
└──────────────┬──────────────────────┘
               │
┌──────────────┴──────────────────────┐
│      Protocol Handler Layer         │
│  OAuth2 │ OIDC │ SAML │ WebAuthn   │
└──────────────┬──────────────────────┘
               │
┌──────────────┴──────────────────────┐
│  Identity Connector Layer (Plugins) │
└──────────────┬──────────────────────┘
               │
┌──────────────┴──────────────────────┐
│         Core Services Layer         │
└─────────────────────────────────────┘
```

## Security

- ✅ OWASP Top 10 protected
- ✅ OAuth 2.0/OIDC compliant
- ✅ Regular security audits
- ✅ Dependency vulnerability scanning

Report security issues to: security@example.com

## License

MIT License - see LICENSE file

## Contributing

See CONTRIBUTING.md