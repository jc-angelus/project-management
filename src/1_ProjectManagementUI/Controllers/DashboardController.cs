﻿using ProjectManagementUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace ProjectManagementUI.Controllers
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: DashboardController
    /// </summary>

    [Authorize]
    public class DashboardController : Controller
    {   
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.BreadCrumbFirstItem = "Dashboard";
            ViewBag.BreadCrumbSecondItem = "";
            return View("Index");
        }     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}