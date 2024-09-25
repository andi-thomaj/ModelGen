using ModelGen.Application.Contracts.Persistence;
using ModelGen.Application.Models.Requests;
using ModelGen.Application.Models.Responses;
using ModelGen.Domain;
using ModelGen.Infrastructure.Database;
using ModelGen.Shared;

namespace ModelGen.Infrastructure.Repositories;

public class GeneticDataRepository(IUserRepository userRepository, ModelGenDbContext dbContext) : IGeneticDataRepository
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

    public async Task<Result> UploadGeneticDataFileAsync(UploadGeneticDataFileRequest request)
    {
        var userResult = await userRepository.GetUserByIdAsync(request.UserId);

        if (userResult.IsFailure)
        {
            return new Result(false,
                new Error(nameof(UploadGeneticDataFileAsync), $"User with ID: {request.UserId} was not found",
                    ErrorType.NotFound));
        }

        List<GeneticData> geneticData = [];
        foreach (var data in request.Files.Files)
        {
            byte[] fileBytes;
            await using (var stream = data.OpenReadStream())
            {
                await using MemoryStream memoryStream = new();
                await stream.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            geneticData.Add(new GeneticData
            {
                RawData = fileBytes,
                RawDataFileName = data.FileName,
                UserId = request.UserId,
                UploadedAt = DateTimeOffset.UtcNow
            });
        }

        await dbContext.GeneticData.AddRangeAsync(geneticData);
        await dbContext.SaveChangesAsync();

        return new Result(true, Error.None);
    }
}