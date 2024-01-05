using Employee_Tracker.Data;
using Employee_Tracker.Models;
using Employee_Tracker.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Employee_Tracker.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;


        //Dependency Injection
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EmployeeViewModel employee)
        {
            var newEmployee = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                IsActive = employee.IsActive,
                DepartmentId = employee.DepartmentId,
            };

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Employee employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public IQueryable<EmployeeViewModel> GetAllAsync()
        {
            var employees = _context.Employees.Select(e => new EmployeeViewModel
            {   
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                DateOfBirth = e.DateOfBirth,
                Gender = e.Gender,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Address = e.Address,
                IsActive = e.IsActive,
                DepartmentId = e.DepartmentId,

            });
            return employees;
        }

        public async Task<List<Department>> GetAllDepartment()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<EmployeeViewModel> GetByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            var employeeViewModel = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                IsActive = employee.IsActive,
                DepartmentId = employee.DepartmentId,
            };
            return employeeViewModel;
        }

        public async Task UpdateAsync(EmployeeViewModel updatedEmployee)
        {
            var employee = await _context.Employees.FindAsync(updatedEmployee.EmployeeId);
            employee.FirstName  = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.Email = updatedEmployee.Email;
            employee.DateOfBirth =  updatedEmployee.DateOfBirth;
            employee.Gender = updatedEmployee.Gender;
            employee.PhoneNumber = updatedEmployee.PhoneNumber;
            employee.Address = updatedEmployee.Address;
            employee.DepartmentId = updatedEmployee.DepartmentId;
            employee.IsActive = updatedEmployee.IsActive;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

        }
    }
}
