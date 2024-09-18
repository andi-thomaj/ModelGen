using ModelGen.Application.Models.Responses;
using ModelGen.Shared;

namespace ModelGen.Application.Contracts.Persistence;

public interface IGeneticDataRepository
{
    Task<Result<GeneticDataResponse>> GetGeneticDataByIdAsync(Guid id);
}