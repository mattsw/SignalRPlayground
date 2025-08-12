using SignalRPlayground.Data.Models.Entities;

namespace SignalRPlayground.Data.Models.Contexts;
using Microsoft.EntityFrameworkCore;

public class LocalPlaygroundContext(DbContextOptions<LocalPlaygroundContext> options) : DbContext(options)
{
    //TODO move this to appsettings/secrets though it's fine for initial dev since there's nothing super scary
    private const string ConnectionString = "data source=DESKTOP-TSFDMTT;initial catalog=LocalPlayground;trusted_connection=true;TrustServerCertificate=true;";
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }
}