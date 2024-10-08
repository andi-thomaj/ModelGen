﻿using ModelGen.Application.Contracts.Business;
using ModelGen.Application.Contracts.Persistence;
using ModelGen.Application.Models.Requests;
using ModelGen.Application.Models.Responses;
using ModelGen.Shared;

namespace ModelGen.Infrastructure.Services;

public class GeneticDataService(IGeneticDataRepository geneticDataRepository) : IGeneticDataService
{
    public async Task<Result<GeneticDataResponse>> GetGeneticDataByIdAsync(Guid id)
    {
        try
        {
            return await geneticDataRepository.GetGeneticDataByIdAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Result> UploadGeneticDataFileAsync(UploadGeneticDataFileRequest request)
    {
        try
        {
            return await geneticDataRepository.UploadGeneticDataFileAsync(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}