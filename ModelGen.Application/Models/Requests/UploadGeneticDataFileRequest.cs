using Microsoft.AspNetCore.Http;

namespace ModelGen.Application.Models.Requests
{
    public record UploadGeneticDataFileRequest(Guid UserId, IFormCollection Files);
}