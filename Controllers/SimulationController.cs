using Microsoft.AspNetCore.Mvc;
using Monty_Hall_API_V3.Models;
using Monty_Hall_API_V3.Services;
using System;

namespace Monty_Hall_API_V3.Controllers
{
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
        public IActionResult SimulateGames([FromBody] SimulationRequest request)
        {
            Console.WriteLine(request);

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var simulationResults = _simulationService.SimulateGames(request.NumberOfSimulations, request.ChangeDoor);

                return Ok(simulationResults);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to application's requirements
                Console.WriteLine($"An error occurred during simulation: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}