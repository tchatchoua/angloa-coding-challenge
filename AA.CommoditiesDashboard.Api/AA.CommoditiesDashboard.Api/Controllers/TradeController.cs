using System.Threading;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AA.CommoditiesDashboard.Api.Controllers;

[ApiController]
[Route("trades")]
[Produces("application/json")]
public class TradesController : ControllerBase
{
    private readonly ITradeService _service;

    public TradesController(ITradeService service)
    {
        _service = service;
    }

    /// <summary>
    ///     Get trades by commodity id
    /// </summary>
    /// <param name="commodityId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returns an <see cref="IEnumerable{T}" /> of type <see cref="TradeDto" /></returns>
    [HttpGet]
    [Route("{commodityId}")]
    public async Task<IActionResult> Get(int commodityId, CancellationToken cancellationToken)
    {
        var model = await _service.GetByCommodityIdAsync(commodityId, cancellationToken);

        return Ok(model);
    }
}