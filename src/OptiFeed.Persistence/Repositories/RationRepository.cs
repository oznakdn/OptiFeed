using Microsoft.EntityFrameworkCore;
using OptiFeed.Core.Dtos;
using OptiFeed.Core.Models;
using OptiFeed.Persistence.Context;

namespace OptiFeed.Persistence.Repositories;

public class RationRepository : IRationRepository
{
    private readonly AppDbContext _dbContext;

    public RationRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddRationAsync(Ration ration,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        await _dbContext.Rations.AddAsync(ration, cancellationToken);
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> UpdateRationAsync(Ration ration,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        _dbContext.Rations.Update(ration);
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> DeleteRationAsync(Ration ration,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        _dbContext.Rations.Remove(ration);
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<Ration> GetRationAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _dbContext.Rations
            .Where(x => x.Id == id)
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<IList<Ration>> GetRationsAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _dbContext.Rations
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<List<AnimalRationDto>> GetRationsWithAnimalAsync(
        CancellationToken cancellationToken = default(CancellationToken))
    {
        var rations = await _dbContext.Rations
            .Include(x => x.RationDetail)
            .Include(x => x.Animal)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var result = rations.Select(x => new AnimalRationDto
        {
            RationId = x.Id,
            AnimalName = x.Animal.Name,
            TagNumber = x.Animal.TagNumber,
            TotalCost = x.RationDetail.TotalCost
        }).ToList();
        
        return result;
    }

    public async Task<AnimalRationDetailsDto> GetRationDetailsAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
    {
        var ration = await _dbContext.Rations
            .Where(x=>x.Id == id) 
            .Include(x => x.RationDetail)
            .ThenInclude(y=>y.FeedItems)
            .Include(x => x.Animal)
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        var result = new AnimalRationDetailsDto
        {
            RationId = ration.Id,
            TotalCost = ration.RationDetail.TotalCost,
            AnimalName = ration.Animal.Name,
            TagNumber = ration.Animal.TagNumber,
            FeedItems = ration.RationDetail.FeedItems.Select(x=> new FeedItemsDto
            {
                FeedName = x.FeedName,
                PricePerKg = x.PricePerKg,
                UsagePercentage = x.UsagePercentage,
                UsageAmountKg = x.UsageAmountKg
            }).ToList()
        };

        return result;
    }
}