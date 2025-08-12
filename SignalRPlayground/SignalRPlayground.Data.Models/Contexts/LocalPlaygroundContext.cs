using SignalRPlayground.Data.Models.Entities;

namespace SignalRPlayground.Data.Models.Contexts;
using Microsoft.EntityFrameworkCore;

public class LocalPlaygroundContext(DbContextOptions<LocalPlaygroundContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}