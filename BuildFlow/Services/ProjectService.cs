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

}

