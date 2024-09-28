using ModelGen.Application.Models.Requests;
using ModelGen.Application.Models.Responses;
using ModelGen.Shared;

namespace ModelGen.Application.Contracts.Business;

public interface IGeneticDataService
{
    Task<Result<GeneticDataResponse>> GetGeneticDataByIdAsync(Guid id);
    Task<Result> UploadGeneticDataFileAsync(UploadGeneticDataFileRequest request);
}