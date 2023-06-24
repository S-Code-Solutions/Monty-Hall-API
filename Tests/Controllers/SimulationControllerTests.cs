using Microsoft.AspNetCore.Mvc;
using Monty_Hall_API_V3.Controllers;
using Monty_Hall_API_V3.Models;
using Monty_Hall_API_V3.Services;
using NUnit.Framework;

namespace Monty_Hall_API_V3.Tests.Controllers
{
    [TestFixture]
    public class SimulationControllerTests
    {
        private SimulationController _controller;
        private ISimulationService _simulationService;

        [SetUp]
        public void Setup()
        {
            _simulationService = new SimulationService(); // Replace with your implementation of ISimulationService
            _controller = new SimulationController(_simulationService);
        }

        [Test]
        public void SimulateGames_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new SimulationRequest
            {
                NumberOfSimulations = 100,
                ChangeDoor = true
            };

            // Act
            var actionResult = _controller.SimulateGames(request);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);
        }

        [Test]
        public void SimulateGames_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var request = new SimulationRequest
            {
                NumberOfSimulations = -1, // Invalid value
                ChangeDoor = true
            };

            // Act
            var actionResult = _controller.SimulateGames(request);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(actionResult.Result);
        }
    }
}