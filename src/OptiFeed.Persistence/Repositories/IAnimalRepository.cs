using OptiFeed.Core.Models;

namespace OptiFeed.Persistence.Repositories;

public interface IAnimalRepository
{
    Task<bool> AddAnimalAsync(Animal animal, CancellationToken cancellationToken = default(CancellationToken));
    Task<bool> UpdateAnimalAsync(Animal animal, CancellationToken cancellationToken = default(CancellationToken));
    Task<bool> DeleteAnimalAsync(Animal animal, CancellationToken cancellationToken = default(CancellationToken));
    Task<Animal> GetAnimalAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
    Task<IList<Animal>> GetAnimalsAsync(CancellationToken cancellationToken = default(CancellationToken));
    Task<int>GetAnimalCountAsync(CancellationToken cancellationToken = default(CancellationToken));
}
