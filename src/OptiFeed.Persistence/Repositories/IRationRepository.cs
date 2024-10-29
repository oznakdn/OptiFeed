using OptiFeed.Core.Models;

namespace OptiFeed.Persistence.Repositories;

public interface IRationRepository
{
    Task<bool> AddRationAsync(Ration ration, CancellationToken cancellationToken = default(CancellationToken));
    Task<bool> UpdateRationAsync(Ration ration, CancellationToken cancellationToken = default(CancellationToken));
    Task<bool> DeleteRationAsync(Ration ration, CancellationToken cancellationToken = default(CancellationToken));
    Task<Ration> GetRationAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
    Task<IList<Ration>> GetRationsAsync(CancellationToken cancellationToken = default(CancellationToken));
}