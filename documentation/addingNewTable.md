# Adding New Table

## Add a New Model

Create a new file in the `Models` directory. Use the following template:

```cs
using Microsoft.AspNetCore.Identity;

namespace hmrc_booking_system_backend.Models
{
    public class UserDetails
    {
        public int id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
```

## Add reference to MyDbContext

Inside `data/MyDbContext.cs`, add a line for the new model:

```bash
    public DbSet<Note> Notes { get; set; }
```

## Create a Controller

Use the code-generator scaffolding in order to create a controller:

```bash
dotnet-aspnet-codegenerator controller -name UserInfoController -async -api -m UserInfo -dc MyDbContext --relativeFolderPath Controllers
```

## Migrate the Model

Run the migration commands to migrate the model and update the database:

```bash
dotnet ef migrations add UserDetailsModel --context MyDbContext
dotnet ef database update --context MyDbContext
```
