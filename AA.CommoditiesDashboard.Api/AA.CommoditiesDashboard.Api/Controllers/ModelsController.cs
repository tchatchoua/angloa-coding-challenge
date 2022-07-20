using System.Threading;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AA.CommoditiesDashboard.Api.Controllers;

[ApiController]
[Route("models")]
[Produces("application/json")]
public class ModelsController : ControllerBase
{
    private readonly IModelService _service;

    public ModelsController(IModelService service)
    {
        _service = service;
    }

    /// <summary>
    ///     Get all models
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Returns an <see cref="IEnumerable{T}" /> of type <see cref="ModelDto" /></returns>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var models = await _service.GetAllAsync(cancellationToken);

        return Ok(models);
    }

    /// <summary>
    ///     Get model by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returns a <see cref="ModelDto" /></returns>
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var model = await _service.GetByIdAsync(id, cancellationToken);

        if (model == null) return NotFound();

        return Ok(model);
    }
}