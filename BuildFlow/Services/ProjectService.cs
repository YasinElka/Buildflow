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
    public async Task<List<Project>> GetProjectsAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Project> CreateProjectAsync(Project project)
    {
        _context.Projects.Add(project); // Add the provided project to the Projects DbSet
        await _context.SaveChangesAsync(); // Save the changes to the database

        return project;
    }

    public async Task<bool> DeleteProjectAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project == null)
        {
            return false;
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task <Project?> UpdateProjectAsync(int id, Project updatedProject)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project == null)
        {
            return null;
        }

        project.Name = updatedProject.Name;
        project.Description = updatedProject.Description;
        project.Status = updatedProject.Status;

       await _context.SaveChangesAsync();

        return project;
    }

}

