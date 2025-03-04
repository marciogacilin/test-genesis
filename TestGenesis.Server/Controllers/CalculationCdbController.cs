using Microsoft.AspNetCore.Mvc;
using TestGenesis.Server.Core.Interfaces;
using TestGenesis.Server.Core.Requests;

namespace TestGenesis.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculationCdbController(ICalculatorCDBService calculatorCDBService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Calculate([FromBody] InputRequest request)
    {
        var result = await calculatorCDBService.Calculate(request.InitialValue, request.Months);

        return Ok(result);
    }
}
