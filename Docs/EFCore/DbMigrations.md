## Database Migrations

### Add migration

```bash
dotnet ef migrations add --context BuberDinnerDbContext --project BuberDinner.Infrastructure --startup-project BuberDinner.Api InitialCreate
```

### Update DB

```bash
dotnet ef database update --context BuberDinnerDbContext --project BuberDinner.Infrastructure --startup-project BuberDinner.Api
```

### Drop DB

```bash
dotnet ef database drop --project BuberDinner.Infrastructure --startup-project BuberDinner.Api
```

## Code Generator

### Install tooling

```bash
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool update --global dotnet-aspnet-codegenerator
```
