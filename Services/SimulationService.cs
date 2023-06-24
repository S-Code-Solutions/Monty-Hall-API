using Monty_Hall_API_V3.Models;
using System;
using System.Linq;

namespace Monty_Hall_API_V3.Services
{
    public class SimulationService : ISimulationService
    {
        public SimulationResult[] SimulateGames(int numberOfSimulations, bool changeDoor)
        {
            var simulationResults = new SimulationResult[numberOfSimulations];
            var random = new Random();

            for (int i = 0; i < numberOfSimulations; i++)
            {
                var doors = new[] { "Car", "Goat", "Goat" };
                var playerChoice = random.Next(0, 3);

                // Monty opens a door with a goat, but not the car
                var validDoors = Enumerable.Range(0, 3)
                    .Where(doorIndex => doorIndex != playerChoice && doors[doorIndex] != "Car")
                    .ToList();

                var montyOpens = validDoors.ElementAtOrDefault(random.Next(0, validDoors.Count));


                // Player changes the door if specified
                if (changeDoor)
                {
                    playerChoice = Enumerable.Range(0, 3)
                        .Where(doorIndex => doorIndex != playerChoice && doorIndex != montyOpens)
                        .First();
                }
                
                // Determine if the player won
                var isWin = doors[playerChoice] == "Car";

                Console.WriteLine($"Player Choice: {playerChoice}");
                Console.WriteLine($"Chosen Door: {doors[playerChoice]}");
                Console.WriteLine($"Is Win: {isWin}");


                simulationResults[i] = new SimulationResult
                {
                    PlayerChoice = playerChoice,
                    MontyOpens = montyOpens,
                    IsWin = isWin
                };
            }

            return simulationResults;
        }
    }
}