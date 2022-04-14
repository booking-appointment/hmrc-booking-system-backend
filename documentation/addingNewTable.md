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
<br>

## Add reference to MyDbContext

Inside `data/MyDbContext.cs`, add a line for the new model:

```bash
    public DbSet<Note> Notes { get; set; }
```
<br>

## Create a Controller

Use the code-generator scaffolding in order to create a controller:

```bash
dotnet-aspnet-codegenerator controller -name UserInfoController -async -api -m UserInfo -dc MyDbContext --relativeFolderPath Controllers
```
<br>

## Migrate the Table

Run the migration commands to migrate the model and update the database:

```bash
dotnet ef migrations add UserDetailsModel --context MyDbContext
dotnet ef database update --context MyDbContext
```
<br>

# Migrate Tables in Heroku DB

## 1. Copy Heroku DB URI

`heroku config -a <APPNAME>` to display DATABASE_URL, then copy the string value

## 2. Run the code to manually migrate the DB on Heroku

`DATABASE_URL="<postgres.URI>" dotnet ef database update`

