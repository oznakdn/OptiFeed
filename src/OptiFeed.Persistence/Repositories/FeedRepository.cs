using Microsoft.EntityFrameworkCore;
using OptiFeed.Core.Models;
using OptiFeed.Persistence.Context;

namespace OptiFeed.Persistence.Repositories;

public class FeedRepository : IFeedRepository
{
    private readonly AppDbContext dbContext;

    public FeedRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }


    public async Task<bool> AddFeedAsync(Feed feed, CancellationToken cancellationToken = default)
    {
        await dbContext.Feeds.AddAsync(feed, cancellationToken);
        return await dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> AddFeedsAsync(IEnumerable<Feed> feeds, CancellationToken cancellationToken = default)
    {
        await dbContext.Feeds.AddRangeAsync(feeds, cancellationToken);
        return await dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> UpdateFeedAsync(Feed feed, CancellationToken cancellationToken = default)
    {
        dbContext.Feeds.Update(feed);
        return await dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> DeleteFeedAsync(Feed feed, CancellationToken cancellationToken = default)
    {
        dbContext.Feeds.Remove(feed);
        return await dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<Feed> GetFeedAsync(int id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Feeds
        .Where(x=>x.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<IList<Feed>> GetFeedsAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Feeds
        .AsNoTracking()
        .ToListAsync(cancellationToken);
    }


}