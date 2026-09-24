using Buildflow.DTOs;
using Buildflow.Models;
using Buildflow.Services;
using Microsoft.AspNetCore.Mvc;

namespace Buildflow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _projectService; //
        public ProjectsController(ProjectService projectService) //
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetProjects()
        {

            var projects = await _projectService.GetProjectsAsync();
            var projectDtos = projects.Select(project => new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Status = project.Status
            }).ToList();

            return Ok(projectDtos);

        }

        [HttpPost]
        public async Task<ActionResult<Project>> CreateProjectAsync(CreateProjectDto project)
        {
            var newProject = new Project
            {
                Name = project.Name,
                Description = project.Description,
                Status = project.Status
            };
            var createdProject = await _projectService.CreateProjectAsync(newProject); // Call the service to create a new project and return the created project with a 201 Created response

            return CreatedAtAction(
                nameof(GetProjects),
                new { id = createdProject.Id },
                createdProject); // Return a 201 Created response with the created project and its location
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectAsync(int id)
        {
            var deleted = await _projectService.DeleteProjectAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task <ActionResult<Project>> UpdateProjectAsync(int id, UpdateProjectDto project)
        {
            var projectToUpdate = new Project
            {
                Name = project.Name,
                Description = project.Description,
                Status = project.Status
            };

            var updatedProject = await _projectService.UpdateProjectAsync(id, projectToUpdate);

            if (updatedProject == null)
            {
                return NotFound();
            }

            return Ok(updatedProject);
        }


    }
}

