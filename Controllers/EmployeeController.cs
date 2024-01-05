using Employee_Tracker.Models;
using Employee_Tracker.Repository;
using Employee_Tracker.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employee_Tracker.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

       public async Task<IActionResult> Index(string searchString, string sortOrder, int pageNumber, string currentFilter)
        {
            ViewData["CurrentSort"] = sortOrder;
            //Sorting
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateOfBirthSortParm"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            ViewData["IsActiveSortParam"] = sortOrder == "isactive_asc" ? "isactive_desc" : "isactive_asc";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var employees =  _employeeRepository.GetAllAsync();

            // Search functionality
            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e => e.FirstName.Contains(searchString) || e.LastName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(e => e.FirstName);
                    break;

                case "date_asc":
                    employees = employees.OrderBy(s => s.DateOfBirth);
                    break;
                case "date_desc":
                    employees = employees.OrderByDescending(s => s.DateOfBirth);
                    break;
                case "isactive_desc":
                    employees = employees.OrderByDescending(e => e.IsActive);
                    break;
                case "isactive_asc":
                    employees = employees.OrderBy(e => e.IsActive);
                    break;

                default:
                    employees = employees.OrderBy(e => e.FirstName);
                    break;
            }

            // Ensure pageNumber is at least 1
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            int pageSize = 5;
            return View(await PaginatedList<EmployeeViewModel>.CreateAsync(employees, pageNumber, pageSize));

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var departments = await _employeeRepository.GetAllDepartment();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            //save the empllloyee
            await _employeeRepository.AddAsync(model);

            //Redirect to main
            return RedirectToAction("Index", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var departments = await _employeeRepository.GetAllDepartment();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");

            //Fetch employee details
            var employee = await _employeeRepository.GetByIdAsync(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee); // returns the form validation errors
            }

            // now update the database with the modified details
            await _employeeRepository.UpdateAsync(employee);

            // Rdirect the list to department page
            return RedirectToAction("Index", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            // delete from the database
            await _employeeRepository.DeleteAsync(id);

            // return to main page
            return RedirectToAction("Index", "Employee");
        }
    }
}
