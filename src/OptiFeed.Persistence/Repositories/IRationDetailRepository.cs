using OptiFeed.Core.Models;

namespace OptiFeed.Persistence.Repositories;

public interface IRationDetailRepository
{
    Task<bool> AddRationDetailAsync(RationDetail rationDetail, CancellationToken cancellationToken = default(CancellationToken));
}