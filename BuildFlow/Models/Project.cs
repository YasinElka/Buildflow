using System.ComponentModel.DataAnnotations;
namespace Buildflow.Models  

{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public ProjectStatus Status { get; set; }


    }
}
