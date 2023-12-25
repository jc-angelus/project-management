using ProjectManagementApplication.Interfaces;
using ProjectManagementInfrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace ProjectManagementApplication.Services
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 09/02/2023
    /// Class: LoginServices
    /// </summary>
    public class LoginServices : ILoginServices
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;                

        public LoginServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;                        

        }

        public async Task<bool> Login(string email, string password)
        {           
            
            ApplicationUser user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {

                SignInResult result = await _signInManager.PasswordSignInAsync(user, password, false, false);

                if (result.Succeeded)
                {

                    return true;
                }
                
                return false;                

            }
            
            return false;
        }

        public void Logout()
        {
            _signInManager.SignOutAsync();            
        }
    }
}
