using Buildflow.Models;
using System.ComponentModel.DataAnnotations;

namespace Buildflow.DTOs;

public class CreateProjectDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public ProjectStatus Status { get; set; }
}