using System.Linq.Expressions;
using OptiFeed.Core.Dtos;
using OptiFeed.Core.Models;

namespace OptiFeed.Persistence.Repositories;

public interface IFeedRepository
{
    Task<bool> AddFeedAsync(Feed feed, CancellationToken cancellationToken = default(CancellationToken));
    Task<bool> AddFeedsAsync(IEnumerable<Feed> feeds, CancellationToken cancellationToken = default(CancellationToken));
    Task<bool> UpdateFeedAsync(Feed feed, CancellationToken cancellationToken = default(CancellationToken));

    Task<bool> UpdateExecuteFeedAsync(int id, double amount,
        CancellationToken cancellationToken = default(CancellationToken));

    Task<bool> DeleteFeedAsync(Feed feed, CancellationToken cancellationToken = default(CancellationToken));
    Task<Feed> GetFeedAsync(int id, CancellationToken cancellationToken = default(CancellationToken));

    Task<Feed> GetFeedByFilterAsync(Expression<Func<Feed, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken));

    Task<IList<Feed>> GetFeedsAsync(CancellationToken cancellationToken = default(CancellationToken));
    Task<int> GetFeedCountAsync(CancellationToken cancellationToken = default(CancellationToken));
    Task<List<FeedAndStockDto>> FeedAndStockChartAsync(CancellationToken cancellationToken= default(CancellationToken));
    Task<List<FeedAndPriceDto>>FeedAndPriceChartAsync(CancellationToken cancellationToken = default(CancellationToken));
}