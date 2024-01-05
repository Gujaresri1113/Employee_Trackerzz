using Azure.Core;
using Employee_Tracker.Models;
using Employee_Tracker.Repository;
using Employee_Tracker.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Tracker.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            // fetch the data
            var departments = await _departmentRepository.GetAllDepartmentListAsync();
            return View(departments);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DepartmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Return the form with validations
            }

            //insert to database
            await _departmentRepository.AddSync(model);

            // Redirect list to the main page
            return RedirectToAction("Index", "Department");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            return View(department);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentViewModel department)
        {
            if (!ModelState.IsValid)
            {
                // return the updated, details to database 
                await _departmentRepository.UpdateAsync(department);

                //Redirect to main page
                return RedirectToAction("Index", "Department");
            }

            // if model is not valid , return the view with validation errors
            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            // Delete data from the datbase
            await _departmentRepository.DeleteAsync(id);

            //return to main page
            return RedirectToAction("Index", "Department");
        }
    }
}
