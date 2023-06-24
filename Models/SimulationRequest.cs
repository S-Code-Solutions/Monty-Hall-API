using System.ComponentModel.DataAnnotations;
namespace Monty_Hall_API_V3.Models;

public class SimulationRequest
{
    [Required]
    [Range(1, int.MaxValue)]
    public int NumberOfSimulations { get; set; }

    public bool ChangeDoor { get; set; }
}