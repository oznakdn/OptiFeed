using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> AddRationAsync(Ration ration, CancellationToken cancellationToken = default(CancellationToken))
    {
        await _dbContext.Rations.AddAsync(ration, cancellationToken);
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> UpdateRationAsync(Ration ration, CancellationToken cancellationToken = default(CancellationToken))
    {
        _dbContext.Rations.Update(ration);
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> DeleteRationAsync(Ration ration, CancellationToken cancellationToken = default(CancellationToken))
    {
        _dbContext.Rations.Remove(ration);
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<Ration> GetRationAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _dbContext.Rations
            .Where(x=>x.Id == id)
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<IList<Ration>> GetRationsAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _dbContext.Rations
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}