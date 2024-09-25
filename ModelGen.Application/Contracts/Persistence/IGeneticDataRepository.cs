using ModelGen.Application.Models.Requests;
using ModelGen.Application.Models.Responses;
using ModelGen.Shared;

namespace ModelGen.Application.Contracts.Persistence;

public interface IGeneticDataRepository
{
    Task<Result<GeneticDataResponse>> GetGeneticDataByIdAsync(Guid id);
    Task<Result> UploadGeneticDataFileAsync(UploadGeneticDataFileRequest request);
}