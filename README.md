# Online Book Store (Implemented the UWP)

This is the demo project of Unit of Work Pattern (UWP) By Using [ASP.NET Core 2.2](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-2.2)

## `RESTful API` developemnt using  [ASP.NET Core 2.2](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-2.2)

### Here, I have created a simple `Bookstore` demo application for `RESTful API` practice purpose.<Enter>

**`Application Features`**

- I used [Postman](https://chrome.google.com/webstore/detail/postman/fhbjgbiflinjbdggehcddcbncdddomop) addons of google chrome browser for checking API data.

### And my instructor name is _[Biswa Nath Ghosh (Tapos)](https://github.com/tapos007)_ :relaxed:

## Development Setup:
#### 1. Create DbContext class in Contexts Directory:

```csharp
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}
```

#### 2. Register the DbContext in the container of the `Startup` class `ConfigureServices` method:

```csharp
var connectionString = Configuration["ConnectionStrings:BookstoreDBConnectionString"];
services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));
```

- Then write the `ConnectionStrings` in `appsettings.Development.json` (For the Development Environment) file:
```csharp
"ConnectionStrings": {
	"BookstoreDBConnectionString": "Server=DESKTOP-ME7EDVE;Database=BookstoreApiDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

## OpenIddict Setup (Token-Based Authentication): 

- Go To [openiddict-core](https://github.com/openiddict/openiddict-core)


