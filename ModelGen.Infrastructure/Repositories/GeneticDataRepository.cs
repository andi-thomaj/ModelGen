using ModelGen.Application.Contracts.Persistence;
using ModelGen.Application.Models.Responses;
using ModelGen.Infrastructure.Database;
using ModelGen.Shared;

namespace ModelGen.Infrastructure.Repositories;

public class GeneticDataRepository(ModelGenDbContext dbContext) : IGeneticDataRepository
{
    public async Task<Result<GeneticDataResponse>> GetGeneticDataByIdAsync(Guid id)
    {
        var geneticData = await dbContext.GeneticData.FindAsync(id);

        if (geneticData is null)
        {
            return new Result<GeneticDataResponse>(null, false, new Error(nameof(GetGeneticDataByIdAsync), $"Genetic data with id: {id} doesn't exist", ErrorType.NotFound));
        }

        return new Result<GeneticDataResponse>(new GeneticDataResponse
        {
            G25Coordinates = geneticData.G25Coordinates,
            MaternalHaplogroup = geneticData.MaternalHaplogroup,
            PaternalHaplogroup = geneticData.PaternalHaplogroup
        }, true, Error.None);
    }
}