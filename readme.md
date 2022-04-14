<!-- Project Documentation

travis tutorial video:
https://www.youtube.com/watch?v=2Ayfi7OJhBI

travis tutorial repo:
https://github.com/rodgtr1/react-net-api-starter

our repo
https://github.com/booking-appointment/hmrc-booking-system-backend

joe fong’s project repo:
https://github.com/kapppa-joe/skillsforcare-appointment-system-backend/tree/main/project

joe fong’s tutorial repo:
https://github.com/kapppa-joe/dotnet-psql-react-demo-project

Markdown tutorial:
https://medium.com/@itsjzt/beginner-guide-to-markdown-229adce30074
# heading 1
## heading 2
- bullet points add `inline code` in the text
```javascript const = codeBlock console.log(codeBlock) ``` -->

# Appointment Booking System Backend

Made Tech Academy 2022 project using ASP.NET CORE, Docker, Postgres, CircleCi and Heroku for the backend

We originally created one app using the ASP.NET Core with React project template (dotnet new react -o my-new-app) but this led to problems with CircleCi so we then created two separate apps for the frontend and backend

## Setup

- install .NET 6.0 then .NET CORE SDK 3.1

- clone repo

- run dotnet build at root

## Create a project

- run:

        dotnet new webapi -o hmrc_booking_system_backend

- cd into project folder, open in VS Code

- run:

        dotnet run

- open localhost:5001

## Create a local database

- open Postgres app

- check the port is 5432 in server settings

- double click on the Postgres database to open Postgres in the terminal

- run:

        CREATE DATABASE hmrcdatabase;
        CREATE USER admin with ENCRYPTED PASSWORD ‘password’;
        CREATE ROLE
        GRANT ALL PRIVILEGES ON DATABASE hmrcdatabase TO admin;

## Connect app to the database

- find NuGet package (https://www.nuget.org/packages?q=postgres): Npgsql.EntityFrameworkCore.PostgreSQL 6.0.3

- go to .NET CLI tab, copy the dotnet add package command, stop app then paste and run the command:

        dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 6.0.3

- go to appsettings.Development.json and add the following code on line 2:

        "ConnectionStrings: {
                "DefaultConnection": "Server=localhost;Port=5432;Database=hmrcdatabase;User Id=admin;Password=password;"
        },

====================
Cat typing 01/04:

- create a Model, call it Note as if creating a Notes app
- create a Models folder: Note.cs
- copy in the followingcode:

using Microsoft.AspNetCore.Identity;

        namespace hmrc_booking_system_backend.Models
        {
                public class Note
                {
                        public int id { get; set; }
                        public string Title { get; set; }
                        public string Description { get; set; }
                }
        }

Next, set up database context:

- Create Data folder at root
- create MyDbContext.cs in Data folder and add in:

// using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Options;
// using Duende.IdentityServer.EntityFramework.Options;
using hmrc_booking_system_backend.Models;

namespace hmrc_booking_system_backend.Data
{
public class MyDbContext : DbContext
{
public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<Note> Notes { get; set; }

    }

}

Startup:

- Create Startup.cs (copied from Joe Fong)
- Change namespace refs and refs to project name (see our Startup.cs file)

Entity Framework Scaffolding:

- Scaffold a controller for our Notes:

  - Install the Entity Framework CLI: dotnet tool install --global dotnet-ef
  - dotnet tool install --global dotnet-aspnet-codegenerator
  - dotnet ef (to make sure it's working - a Unicorn should appear)
  - dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.3
  - dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 6.0.2
  - run dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.3

  - run dotnet-aspnet-codegenerator (may need to put in full path: $HOME/ .dotnet/tools/dotnet-aspnet-codegenerator)
  - Create a Notes controller: run controller -name NotesController -async -api -m Note -dc MyDbContext --relativeFolderPath Controllers

Next, relay the model to the database by creating a migration (we first installed two packages we were missing):
dotnet add package Microsoft.EntityFrameworkCore --version 6.0.3

dotnet add package Microsoft.NET.Sdk.Functions --version 4.1.0 (may not be necessary)

dotnet ef migrations add InitialCreate --context MyDbContext

dotnet ef database update --context MyDbContext
run dotnet run
Open Postman, in GET field, type in local host URL + ‘api/Notes’ route (found in PostmanNotesController.cs POST section)
In Body tab, select raw and JSON

# Migrate Tables in Heroku DB

## 1. Copy Heroku DB URI

`heroku config -a <APPNAME>` to display DATABASE_URL, then copy the string value

## 2. Run the code to manually migrate the DB on Heroku

`DATABASE_URL="<postgres.URI>" dotnet ef database update`
