using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OptiFeed.Core.Dtos;
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

    public async Task<bool> UpdateExecuteFeedAsync(int id, double amount,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        var result = await dbContext.Feeds
            .Where(b => b.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(b => b.Stock, amount),cancellationToken);
        
        return result > 0;
    }

    public async Task<bool> DeleteFeedAsync(Feed feed, CancellationToken cancellationToken = default)
    {
        dbContext.Feeds.Remove(feed);
        return await dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<Feed> GetFeedAsync(int id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Feeds
            .Where(x => x.Id == id)
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<Feed> GetFeedByFilterAsync(Expression<Func<Feed, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        return await dbContext.Feeds
            .Where(filter)
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<IList<Feed>> GetFeedsAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Feeds
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetFeedCountAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return await dbContext.Feeds.CountAsync(cancellationToken);
    }

    public async Task<List<FeedAndStockDto>> FeedAndStockChartAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        var groupedFeeds = await dbContext.Feeds
            .GroupBy(f => f.Name)
            .Select(g=>new 
            {
                FeedName = g.Key,
                Stock = g.Sum(x=>Math.Round(x.Stock,2))
            }).ToListAsync(cancellationToken);

        return groupedFeeds.Select(x=> new FeedAndStockDto
        {
            FeedName = x.FeedName,
            Stock = x.Stock,
        }).ToList();

    }

    public async Task<List<FeedAndPriceDto>> FeedAndPriceChartAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        var gropedFeed = await dbContext.Feeds
            .GroupBy(x => x.Name)
            .Select(x => new
            {
                FeedName = x.Key,
                Price = x.Sum(x=>x.CostPerKg)
            }).ToListAsync(cancellationToken);
        return gropedFeed.Select(x => new FeedAndPriceDto
        {
            FeedName = x.FeedName,
            Price = x.Price
        }).ToList();
    }
}