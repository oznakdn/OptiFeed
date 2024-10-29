using OptiFeed.Core.Models;

namespace OptiFeed.Persistence.Repositories;

public interface IRatioFeedItemRepository
{
    Task<bool>AddRationFeedItemsAsync(IEnumerable<RationFeedItem>feedItems, CancellationToken cancellationToken = default(CancellationToken));
}