using SignalRPlayground.Data.Models.Entities;

namespace SignalRPlayground.Data.Models.Contexts;
using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext
{
    string connectionString = "data source=DESKTOP-TSFDMTT;initial catalog=LocalPlayground;trusted_connection=true;TrustServerCertificate=true;";
    DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}