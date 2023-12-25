using Microsoft.AspNetCore.Identity;

namespace ProjectManagementDomain.Models
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 09/02/2023
    /// Class: ApplicationUserModel
    /// </summary
    public class ApplicationUserModel: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
