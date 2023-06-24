using Monty_Hall_API_V3.Models;
using Monty_Hall_API_V3.Services;
using NUnit.Framework;
namespace Monty_Hall_API_V3.Tests.Services;

[TestFixture]
public class SimulationServiceTests
{
    private SimulationService _simulationService;

    [SetUp]
    public void Setup()
    {
        _simulationService = new SimulationService();
    }

    [Test]
    public void SimulateGames_ReturnsExpectedNumberOfResults()
    {
        // Arrange
        int numberOfSimulations = 100;
        bool changeDoor = true;

        // Act
        SimulationResult[] results = _simulationService.SimulateGames(numberOfSimulations, changeDoor);

        // Assert
        Assert.AreEqual(numberOfSimulations, results.Length);
    }

    [Test]
    public void SimulateGames_ResultsContainValidValues()
    {
        // Arrange
        int numberOfSimulations = 10;
        bool changeDoor = false;

        // Act
        SimulationResult[] results = _simulationService.SimulateGames(numberOfSimulations, changeDoor);

        // Assert
        foreach (var result in results)
        {
            Assert.That(result.PlayerChoice, Is.GreaterThanOrEqualTo(0).And.LessThan(3));
            Assert.That(result.MontyOpens, Is.GreaterThanOrEqualTo(0).And.LessThan(3));
            Assert.That(result.IsWin, Is.EqualTo(true).Or.EqualTo(false));
        }
    }
}