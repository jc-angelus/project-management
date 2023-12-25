using System.ComponentModel.DataAnnotations;

namespace ProjectManagementDomain.Models
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: UserLoginModel
    /// </summary
    public class UserLoginModel
    {       
        
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
