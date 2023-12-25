using ProjectManagementApplication.Interfaces;
using ProjectManagementDomain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementUI.Controllers
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 09/02/2023
    /// Class: AccountController
    /// </summary>
    public class AccountController: Controller
    {

        public readonly ILoginServices _loginServices;        

        public AccountController(ILoginServices loginServices)
        {
            _loginServices = loginServices;            
        }        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginModel loginModel)
        {
            if (ModelState.IsValid)
            {


                bool login = await _loginServices.Login(loginModel.Email, loginModel.Password);


                if (login)
                {
                    return RedirectToAction("Index", "Dashboard");

                }
                else
                {
                    ModelState.AddModelError("", "Login Error");
                    ViewBag.Message = "Login Error";
                    return View(loginModel);
                }
               
            }
            else
            {
                ModelState.AddModelError("", "Please check the credentials");
                ViewBag.Message = "Please check the credentials";
            }

            return View(loginModel);
        }        


        public IActionResult LogOut()
        {
            _loginServices.Logout();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }        
    }
}
