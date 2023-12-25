using ProjectManagementApplication.Interfaces;
using ProjectManagementDomain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ProjectManagementUI.Controllers
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: ProjectsController
    /// </summary>

    [Authorize]
    public class ProjectsController : Controller
    {

        public readonly IStatesServices _statesServices;
        public readonly IProjectsServices _projectsServices;

        public ProjectsController(IStatesServices statesServices, IProjectsServices projectsServices)
        {
            _statesServices = statesServices;
            _projectsServices = projectsServices;
        }

        public async Task<IActionResult> Index()
        {
            var listprojects = await _projectsServices.ProjectsListAsync();            
            ViewBag.BreadCrumbFirstItem = "Projects";
            ViewBag.BreadCrumbSecondItem = "List Projectss";
            return View(listprojects);           
            
        }

        public async Task<IActionResult> Create()
        {
            var projectsModel = new ProjectsModel();
            var liststateModel = await _statesServices.StatesListAsync();
            projectsModel.StatesList = liststateModel.Select(x => new ItemListModel { Value = x.Id, Text = x.Name }).ToList();
            ViewBag.BreadCrumbFirstItem = "Projects";
            ViewBag.BreadCrumbSecondItem = "Create projects";
            return View(projectsModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectsModel projectsModel)
        {

            await _projectsServices.CreateProjectsAsync(projectsModel);
            var listprojects = await _projectsServices.ProjectsListAsync();            

            ViewBag.BreadCrumbFirstItem = "Projects";
            ViewBag.BreadCrumbSecondItem = "List projectss";
            return View("Index", listprojects);

        }

        public async Task<IActionResult> Details(int id)
        {
            var liststateModel = await _statesServices.StatesListAsync();
            var projectsModel = await _projectsServices.ReadProjectsAsync(id);
            projectsModel.StatesList = liststateModel.Select(x => new ItemListModel { Value = x.Id, Text = x.Name }).ToList();
            ViewBag.BreadCrumbFirstItem = "Projects";
            ViewBag.BreadCrumbSecondItem = "Detail Projects";            
            return View(projectsModel);

        }

        public async Task<IActionResult> Edit(int id)
        {

            var liststateModel = await _statesServices.StatesListAsync();
            var projectsModel = await _projectsServices.ReadProjectsAsync(id);
            projectsModel.StatesList = liststateModel.Select(x => new ItemListModel { Value = x.Id, Text = x.Name }).ToList();
            ViewBag.BreadCrumbFirstItem = "Projects";
            ViewBag.BreadCrumbSecondItem = "Edit Projects";            
            return View(projectsModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectsModel projectsModel)
        {
            await _projectsServices.UpdateProjectsAsync(projectsModel);
            var listprojects = await _projectsServices.ProjectsListAsync();
            ViewBag.BreadCrumbFirstItem = "Projects";
            ViewBag.BreadCrumbSecondItem = "Edit Projects";
            return View("Index", listprojects);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _projectsServices.DeleteProjectsAsync(id);
            var listprojects = await _projectsServices.ProjectsListAsync();
            ViewBag.BreadCrumbFirstItem = "Projects";
            ViewBag.BreadCrumbSecondItem = "List Projects";
            return View("Index", listprojects);

        }

    }
}
