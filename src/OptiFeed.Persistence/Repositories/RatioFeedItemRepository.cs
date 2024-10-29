using OptiFeed.Core.Models;
using OptiFeed.Persistence.Context;

namespace OptiFeed.Persistence.Repositories;

public class RatioFeedItemRepository : IRatioFeedItemRepository
{
    private readonly AppDbContext _dbContext;

    public RatioFeedItemRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddRationFeedItemsAsync(IEnumerable<RationFeedItem> feedItems, CancellationToken cancellationToken = default(CancellationToken))
    {
        await _dbContext.RationFeedItems.AddRangeAsync(feedItems, cancellationToken);
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}