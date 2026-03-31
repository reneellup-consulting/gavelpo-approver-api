# Notes
### Dotnet Super Secrets
In the API Project folder, run the following commands to set up the user secrets for the API project.

To set up the user secrets, run the following command:
```console
dotnet user-secrets init
```

To set the secret key, run the following command:
```console
dotnet user-secrets set "JwtSettings:Secret" "super-secret-key-from-user-secrets"
```

To view the secret key, run the following command:
```console
dotnet user-secrets init
```