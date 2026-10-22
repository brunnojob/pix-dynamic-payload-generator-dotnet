# Pix Dynamic Payload Generator for .NET

C# library for Pix payloads and PSP API integration. Imported from the supplied source archive of [Alexandre Sanlim’s project](https://github.com/alexandresanlim/pix-dynamic-payload-generator.net).

## Features

- Static Pix payload generation through the original dependency.
- Immediate and due-date charge requests.
- Pix lookup, refund requests and webhook configuration.
- OAuth credentials and client certificates for PSP integration.

Dynamic operations require a compatible PSP, internet access and credentials issued by that provider. Static payload generation alone does not confirm payment.

## Build and test

```sh
dotnet restore pix-dynamic-payload-generator.net.sln
dotnet build pix-dynamic-payload-generator.net.sln --configuration Release --no-restore
dotnet test pix-dynamic-payload-generator.net.sln --configuration Release --no-build --filter 'TestCategory!=Integration'
```

Use the .NET 8 SDK. The library targets .NET Standard 2.0; the test project targets .NET 8. CI runs the build and the offline QR payload test.

## Configuration

`.env.example` lists configuration names with empty values. Set them as environment variables in your shell or deployment environment; the library does not load `.env` files automatically. Do not commit credentials or certificates.

Integration tests are excluded from CI. Running them requires `PIX_ENABLE_INTEGRATION=true`, PSP sandbox credentials, a certificate and the relevant test identifiers. They can create charges, register webhooks or request refunds on the configured account. Use only a sandbox configured for testing.

This source import removes code comments, unused commented-out files and fixed example identities, Pix keys and transaction identifiers. Integration test values come from environment variables. The offline test generates a temporary synthetic key and does not contact a bank.

## Origin and license

Derived from [alexandresanlim/pix-dynamic-payload-generator.net](https://github.com/alexandresanlim/pix-dynamic-payload-generator.net). Original copyright: Alexandre Sanlim. The original MIT license is preserved in [LICENSE](LICENSE). This repository is a source derivative, not a new release of the original NuGet package.
