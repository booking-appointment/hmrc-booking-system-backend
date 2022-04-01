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