using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestGenesis.Server.Application.Commands;

namespace TestGenesis.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculationCdbController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Calculate([FromBody] CalculateCDBCommand request)
    {
        var result = await mediator.Send(request);

        return Ok(result);
    }
}
