Wizard of Auth is a modular authentication and authorization solution for web applications or systems needing one. 
It provides a flexible and extensible way to manage user authentication, roles, and permissions.
Ideal for implementing robust security features in their applications on the fly, without reinventing the 
wheel or depending on a service.

## Architecture

┌─────────────────────────────────────────────┐
│           API Gateway Layer                 │
│  (REST/gRPC endpoints for all protocols)    │
└─────────────────────────────────────────────┘
↓
┌─────────────────────────────────────────────┐
│         Protocol Handler Layer              │
│  ┌──────────┬──────────┬──────────────┐    │
│  │ OAuth2.0 │   OIDC   │    SAML 2.0  │    │
│  └──────────┴──────────┴──────────────┘    │
└─────────────────────────────────────────────┘
↓
┌─────────────────────────────────────────────┐
│      Identity Provider Connector Layer      │
│  (Plugin-based architecture)                │
└─────────────────────────────────────────────┘
↓
┌─────────────────────────────────────────────┐
│         Core Services Layer                 │
│  • Token Management  • Session Management   │
│  • User Store       • Crypto/PKI Service    │
└─────────────────────────────────────────────┘

## Features
- **Modular Protocol Support**: Easily add or remove authentication protocols like OAuth2.0, OIDC, SAML 2.0, etc.