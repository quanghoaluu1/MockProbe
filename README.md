# MockProbe

MockProbe is an open-source, self-hostable AI mock interview practice platform. The current repository is an initial scaffold with a .NET Clean Architecture API and a reserved web app folder.

## Structure

```text
web_app/
api/
  src/
    MockProbe.Api
    MockProbe.Application
    MockProbe.Domain
    MockProbe.Infrastructure
  tests/
    MockProbe.UnitTests
    MockProbe.IntegrationTests
```

## Services

The root `docker-compose.yml` starts:

- PostgreSQL for relational data
- Redis for future background jobs, caching, and rate limiting
- MinIO for future self-hosted object storage

Start dependencies:

```bash
cp .env.example .env
docker compose up -d
```

## API

Run the API:

```bash
cd api
dotnet restore
dotnet build
dotnet run --project src/MockProbe.Api
```

Useful endpoints:

- `GET /health`
- `GET /swagger`
- `GET /api/system/config`

## Auth Modes

Auth is intentionally only configured as placeholders for now:

- `AUTH_MODE=none` for self-hosted local usage
- `AUTH_MODE=local` for future email and password auth
- `AUTH_MODE=oauth` for future OAuth auth

The API also accepts standard ASP.NET Core configuration keys such as `Auth__Mode` and `ConnectionStrings__DefaultConnection`.
