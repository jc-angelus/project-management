using System.ComponentModel.DataAnnotations;

namespace ProjectManagementDomain.Models
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: TasksModel
    /// </summary
    public class TasksModel
    {           
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Project is required")]
        public int ProjectsId { get; set; }
        public List<ItemListModel> ProjectsList { get; set; } = null!;

        [Required(ErrorMessage = "State is required")]
        public int StatesId { get; set; }
        public StatesModel StatesModel { get; set; } = null!;
        public List<ItemListModel> StatesList { get; set; } = null!;
    }
}
