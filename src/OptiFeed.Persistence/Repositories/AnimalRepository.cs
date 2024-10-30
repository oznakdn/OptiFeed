using Microsoft.EntityFrameworkCore;
using OptiFeed.Core.Models;
using OptiFeed.Persistence.Context;

namespace OptiFeed.Persistence.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private readonly AppDbContext dbContext;

    public AnimalRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<bool> AddAnimalAsync(Animal animal, CancellationToken cancellationToken = default)
    {
        await dbContext.Animals.AddAsync(animal, cancellationToken);
        return await dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> DeleteAnimalAsync(Animal animal, CancellationToken cancellationToken = default)
    {
        dbContext.Animals.Remove(animal);
        return await dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<Animal> GetAnimalAsync(int id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Animals
        .Where(x => x.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<IList<Animal>> GetAnimalsAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Animals
        .AsNoTracking()
        .ToListAsync(cancellationToken);
    }

    public async Task<int> GetAnimalCountAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return await dbContext.Animals.CountAsync(cancellationToken);
    }

    public async Task<bool> UpdateAnimalAsync(Animal animal, CancellationToken cancellationToken = default)
    {
        dbContext.Animals.Update(animal);
        return await dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}
