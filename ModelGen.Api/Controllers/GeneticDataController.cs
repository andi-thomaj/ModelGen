using Microsoft.AspNetCore.Mvc;
using ModelGen.Application.Contracts.Business;
using ModelGen.Application.Models.Responses;
using ModelGen.Shared;

namespace ModelGen.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeneticDataController(IGeneticDataService geneticDataService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<GeneticDataResponse>> GetGeneticDataByIdAsync(Guid id)
    {
        var result = await geneticDataService.GetGeneticDataByIdAsync(id);

        return result switch
        {
            { IsFailure: true, Error.Type: ErrorType.NotFound } => NotFound(result.Error.Description),
            { IsFailure: true } => BadRequest(),
            _ => result.Value
        };
    }

}