using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Tracing;
using Monty_Hall_API_V3.Models;
using Monty_Hall_API_V3.Services;
namespace Monty_Hall_API_V3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SimulationController : ControllerBase
{
    private readonly ISimulationService _simulationService;

    public SimulationController(ISimulationService simulationService)
    {
        _simulationService = simulationService;
    }

    [HttpPost]
    public ActionResult<SimulationResult> SimulateGames([FromBody] SimulationRequest request)
    {
        Console.WriteLine(request);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var simulationResults = _simulationService.SimulateGames(request.NumberOfSimulations, request.ChangeDoor);

        return Ok(simulationResults);
    }
}