using Microsoft.EntityFrameworkCore;
using OptiFeed.Core.Models;

namespace OptiFeed.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Feed> Feeds { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Ration> Rations { get; set; }
    public DbSet<RationDetail> RationDetails { get; set; }
    public DbSet<RationFeedItem> RationFeedItems { get; set; }



}
