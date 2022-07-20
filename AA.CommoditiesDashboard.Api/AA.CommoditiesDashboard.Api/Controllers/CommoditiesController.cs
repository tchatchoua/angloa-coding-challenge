using System.Threading;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AA.CommoditiesDashboard.Api.Controllers;

[ApiController]
[Route("commodities")]
[Produces("application/json")]
public class CommoditiesController : ControllerBase
{
    private readonly ICommodityService _service;

    public CommoditiesController(ICommodityService service)
    {
        _service = service;
    }

    /// <summary>
    ///     Get all commodities
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Returns an <see cref="IEnumerable{T}" /> of type <see cref="CommodityDto" /></returns>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var models = await _service.GetAllAsync(cancellationToken);

        return Ok(models);
    }

    /// <summary>
    ///     Get commodities by model id
    /// </summary>
    /// <param name="modelId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returns an <see cref="IEnumerable{T}" /> of type <see cref="CommodityDto" /></returns>
    [HttpGet]
    [Route("{modelId}")]
    public async Task<IActionResult> Get(int modelId, CancellationToken cancellationToken)
    {
        var model = await _service.GetByModelIdAsync(modelId, cancellationToken);

        return Ok(model);
    }
}