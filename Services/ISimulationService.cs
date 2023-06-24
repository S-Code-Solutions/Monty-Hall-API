using Monty_Hall_API_V3.Models;
namespace Monty_Hall_API_V3.Services;

public interface ISimulationService
{
    SimulationResult[] SimulateGames(int numberOfSimulations, bool changeDoor);
}
