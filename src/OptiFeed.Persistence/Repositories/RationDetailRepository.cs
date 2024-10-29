using OptiFeed.Core.Models;
using OptiFeed.Persistence.Context;

namespace OptiFeed.Persistence.Repositories;

public class RationDetailRepository : IRationDetailRepository
{
    private readonly AppDbContext _dbContext;

    public RationDetailRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddRationDetailAsync(RationDetail rationDetail, CancellationToken cancellationToken = default(CancellationToken))
    {
        await _dbContext.RationDetails.AddAsync(rationDetail, cancellationToken);
        return  await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}