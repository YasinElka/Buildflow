namespace Buildflow.Data;
using Buildflow.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext // This class represents the database context for the application
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // This constructor initializes the AppDbContext with the provided options
    {
    }
    public DbSet<Project> Projects { get; set; } // This property represents the Projects table in the database
}

