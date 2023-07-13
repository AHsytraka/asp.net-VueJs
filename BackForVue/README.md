## ASP.NET Core Project Setup

### Change the connection string in appsettings.json to match your database informations
### Note that I didn't make the migration run automatically because this is a small project :)

### Install all dependecies

```sh
dotnet restore
```

### Run migration (if there is no migration folder)
```sh
dotnet ef migrations "string"
```
### Update database
```sh
dotnet ef database update
```

### Compile and Run the project
```sh
dotnet run
```

### Compile and Hot-Reload for Development

```sh
dotnet watch -q run
```
