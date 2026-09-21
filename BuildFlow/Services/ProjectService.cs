namespace Buildflow.Services;
using Buildflow.Data;
using Buildflow.Models;
using Microsoft.EntityFrameworkCore;
public class ProjectService

{
    private readonly AppDbContext _context; // This field holds the database context for the service

    public ProjectService(AppDbContext context) // This constructor initializes the ProjectService with the provided database context
    {
        _context = context; // Assign the provided database context to the private field
    }
    public List<Project> GetProjects() // This method returns a list of projects
    {


        return _context.Projects.ToList();

    }

    public Project CreateProject(Project project)
    {
        _context.Projects.Add(project); // Add the provided project to the Projects DbSet
        _context.SaveChanges(); // Save the changes to the database

        return project;
    }

    public bool DeleteProject(int id)
    {
        var project = _context.Projects.Find(id);

        if (project == null)
        {
            return false;
        }

        _context.Projects.Remove(project);
        _context.SaveChanges();

        return true;
    }

    public Project? UpdateProject(int id, Project updatedProject)
    {
        var project = _context.Projects.Find(id);

        if (project == null)
        {
            return null;
        }

        project.Name = updatedProject.Name;
        project.Description = updatedProject.Description;
        project.Status = updatedProject.Status;

        _context.SaveChanges();

        return project;
    }

}

