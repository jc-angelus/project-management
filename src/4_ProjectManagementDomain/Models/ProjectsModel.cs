using System.ComponentModel.DataAnnotations;

namespace ProjectManagementDomain.Models
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: ProjectsModel
    /// </summary
    public class ProjectsModel
    {
        public ProjectsModel() { 
        
            this.TasksModel = new List<TasksModel>();
            this.StatesList = new List<ItemListModel>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "State is required")]
        public int StatesId { get; set; }
        public StatesModel StatesModel { get; set; }
        public IEnumerable<TasksModel> TasksModel { get; set; } = null!;        
        public List<ItemListModel> StatesList { get; set; } = null!;

    }
}
