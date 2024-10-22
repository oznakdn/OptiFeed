using Microsoft.EntityFrameworkCore;
using OptiFeed.Core.Models;

namespace OptiFeed.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Feed> Feeds { get; set; }
}
