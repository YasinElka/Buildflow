using Microsoft.AspNetCore.Mvc;
using Buildflow.Services;
using Buildflow.Models;

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
        public List<Project> GetProjects()
        {

            return _projectService.GetProjects(); // Call the service to get the list of projects and return it
        }

        [HttpPost]
        public ActionResult<Project> CreateProject(Project project)
        {
            var createdProject = _projectService.CreateProject(project); // Call the service to create a new project and return the created project with a 201 Created response

            return CreatedAtAction( 
                nameof(GetProjects),
                new { id = createdProject.Id },
                createdProject); // Return a 201 Created response with the created project and its location
        }

    }
}

