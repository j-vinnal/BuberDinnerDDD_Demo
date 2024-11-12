# Managing Secrets with .NET Core Secret Manager

## Overview

The .NET Core Secret Manager tool allows you to store sensitive data, like JWT secrets, securely outside of your project's `appsettings.json` file. This is useful for development environments to avoid hardcoding sensitive information in your source code.

## Steps

### 1. Initialize User Secrets

Initialize the Secret Manager for your project:
```bash
dotnet user-secrets init --project .\BuberDinner.Api\
```

This command sets up the Secret Manager for the `BuberDinner.Api` project.

### 2. Set a Secret

Set a secret value using the Secret Manager:

```bash
dotnet user-secrets set --project .\BuberDinner.Api\ "JwtSettings:Secret" "jS+eHHzXxz4dSnrh1KwrGw==gfdFHFa-..-372-"
```

This command stores the JWT secret key securely in the user secrets store.

### 3. Verify the Secret

List all the secrets stored for your project to verify:

```bash
dotnet user-secrets list --project .\BuberDinner.Api\
```

This command will display the stored secrets, confirming that the JWT secret key is saved.