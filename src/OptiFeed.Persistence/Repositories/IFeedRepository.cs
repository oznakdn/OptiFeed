using OptiFeed.Core.Models;

namespace OptiFeed.Persistence.Repositories;

public interface IFeedRepository
{
    Task<bool>AddFeedAsync(Feed feed, CancellationToken cancellationToken = default(CancellationToken));
    Task<bool>AddFeedsAsync(IEnumerable<Feed>feeds, CancellationToken cancellationToken = default(CancellationToken));
    Task<bool>UpdateFeedAsync(Feed feed, CancellationToken cancellationToken = default(CancellationToken));
    Task<bool>DeleteFeedAsync(Feed feed, CancellationToken cancellationToken = default(CancellationToken));
    Task<Feed>GetFeedAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
    Task<IList<Feed>>GetFeedsAsync(CancellationToken cancellationToken = default(CancellationToken));
}