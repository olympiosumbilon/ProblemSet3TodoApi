# ProblemSet3.2 — Todo List (API + React Client)

This repo contains:
- ASP.NET Core Web API (`TodoListApi`) using SQL Server
- React client (`todoclient`)
- Docker Compose to run API + SQL Server

## Prerequisites
- Docker Desktop running
- Git
- Optional (for migrations from host): .NET 8 SDK (`dotnet --version`)

## Quick Start (Docker Compose)
1) Clone the repo
```powershell
git clone https://github.com/olympiosumbilon/ProblemSet3TodoApi.git
cd ProblemSet3TodoApi
```

2) Start containers (API + SQL Server)
```powershell
docker compose up -d --build
```
- API: `http://localhost:8080`
- Swagger: `http://localhost:8080/swagger`
- SQL Server: `localhost:1433` (user: `sa`, password: `@dmin123`)

3) Apply EF Core migrations (create database schema)
- From your host (requires .NET SDK):
```powershell
dotnet tool install -g dotnet-ef
$env:ConnectionStrings__DefaultConnection="Server=localhost,1433;Database=DbTodoList;User=sa;Password=@dmin123;TrustServerCertificate=True"
dotnet ef database update --project .\TodoListApi --startup-project .\TodoListApi
```
Notes:
- Run this once after first start, and again only if new migrations are added.
- If you prefer, you can exec into the container and run migrations from a build image, but the above is simplest.

## React Client (local dev)
1) Point the client to the compose API URL
- Edit `todoclient/src/services/api.ts` base URL:
```ts
baseURL: "http://localhost:8080/api"
```

2) Install and run
```powershell
cd todoclient
npm ci
npm start
```
- Dev server: `http://localhost:3000`

## Common Commands
- View logs
```powershell
docker compose logs -f api
```
- Restart API only
```powershell
docker compose up -d --build api
```
- Stop and remove containers
```powershell
docker compose down
```
- Remove volumes (clears SQL data!)
```powershell
docker compose down -v
```

## Configuration
- API listens on port `5000` in-container, mapped to host `8080` in `docker-compose.yml`.
- Connection string (compose) is set via environment:
```
Server=db,1433;Database=DbTodoList;User=sa;Password=@dmin123;TrustServerCertificate=True
```
- Local development appsettings uses `(local)`; when running via Compose, the above env var is used instead.

## Troubleshooting
- SQL Server container not ready: wait 10–20s after `up -d` before applying migrations.
- Port conflicts: change `8080:5000` in `docker-compose.yml` if 8080 is in use.
- EF tools not found: open a new terminal after `dotnet tool install -g dotnet-ef` or add the dotnet tools path to your `PATH`.

## License
This project is for educational purposes.
