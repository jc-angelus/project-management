using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementInfrastructure.Entities
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: States
    /// </summary>

    [Table("States")]
    public class States
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = null!;                                    

    }
}
