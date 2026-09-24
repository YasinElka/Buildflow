using Buildflow.Models;

namespace Buildflow.DTOs;

public class ProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ProjectStatus Status { get; set; }
}