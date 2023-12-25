using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementInfrastructure.Entities
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: Projects
    /// </summary>

    [Table("Projects")]
    public class Projects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = null!;               

        [StringLength(250)]
        public string Description { get; set; } = null!;
        public virtual int StatesId { get; set; }
        public virtual States States { get; set; } = null!;
        public virtual IEnumerable<Tasks> Tasks { get; set; } = null!;

    }
}
