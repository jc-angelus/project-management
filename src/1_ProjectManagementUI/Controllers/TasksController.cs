using ProjectManagementApplication.Interfaces;
using ProjectManagementDomain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementUI.Controllers
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Class: TaskController
    /// </summary>

    [Authorize]
    public class TaskController : Controller
    {
        public readonly IStatesServices _statesServices;
        public readonly ITasksServices _taskServices;
        public readonly IProjectsServices _projectServices;

        public TaskController(IStatesServices statesServices, ITasksServices taskServices, IProjectsServices projectServices)
        {
            _statesServices = statesServices;
            _taskServices = taskServices;
            _projectServices = projectServices;
        }

        public async Task<IActionResult> Index()
        {
            var listtasks = await _taskServices.TasksListAsync();            
            ViewBag.BreadCrumbFirstItem = "Task";
            ViewBag.BreadCrumbSecondItem = "List Tasks";
            return View(listtasks);           
            
        }

        public async Task<IActionResult> Create()
        {
            var taskModel = new TasksModel();            
            var liststateModel = await _statesServices.StatesListAsync();
            taskModel.StatesList = liststateModel.Select(x => new ItemListModel { Value = x.Id, Text = x.Name }).ToList();
            var listprojectModel = await _projectServices.ProjectsListAsync();
            taskModel.ProjectsList = listprojectModel.Select(x => new ItemListModel { Value = x.Id, Text = x.Name }).ToList();
            ViewBag.BreadCrumbFirstItem = "Task";
            ViewBag.BreadCrumbSecondItem = "Create Task";
            return View(taskModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TasksModel taskModel)
        {

            await _taskServices.CreateTasksAsync(taskModel);
            var listtasks = await _taskServices.TasksListAsync();
            ViewBag.BreadCrumbFirstItem = "Task";
            ViewBag.BreadCrumbSecondItem = "Create Task";
            return View("Index", listtasks);

        }       

        public async Task<IActionResult> Edit(int id)
        {            
            var taskModel = await _taskServices.ReadTasksAsync(id);
            var liststateModel = await _statesServices.StatesListAsync();
            taskModel.StatesList = liststateModel.Select(x => new ItemListModel { Value = x.Id, Text = x.Name }).ToList();
            var listprojectModel = await _projectServices.ProjectsListAsync();
            taskModel.ProjectsList = listprojectModel.Select(x => new ItemListModel { Value = x.Id, Text = x.Name }).ToList();
            ViewBag.BreadCrumbFirstItem = "Task";
            ViewBag.BreadCrumbSecondItem = "Edit Task";            
            return View(taskModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TasksModel taskModel)
        {
            await _taskServices.UpdateTasksAsync(taskModel);
            var listtasks = await _taskServices.TasksListAsync();
            ViewBag.BreadCrumbFirstItem = "Task";
            ViewBag.BreadCrumbSecondItem = "Edit Task";
            return View("Index", listtasks);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _taskServices.DeleteTasksAsync(id);
            var listtasks = await _taskServices.TasksListAsync();
            ViewBag.BreadCrumbFirstItem = "Task";
            ViewBag.BreadCrumbSecondItem = "List Task";
            return View("Index", listtasks);

        }

    }
}
