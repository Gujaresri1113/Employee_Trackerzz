using Employee_Tracker.Data;
using Employee_Tracker.Models;
using Employee_Tracker.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Employee_Tracker.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly ApplicationDbContext _context;

        //DI
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddSync(DepartmentViewModel department)
        {
            var newDepartment = new Department()
            {
                Name = department.Name
            };
            await _context.Departments.AddAsync(newDepartment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           Department department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DepartmentViewModel>> GetAllDepartmentListAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            List<DepartmentViewModel> departmentsViewModels = new List<DepartmentViewModel>();
            foreach (var department in departments)
            {
                var deparmentViewModel = new DepartmentViewModel
                {
                    DepartmentId = department.DepartmentId,
                    Name = department.Name
                };

                departmentsViewModels.Add(deparmentViewModel);
            }

            return departmentsViewModels;
        }

        public async Task<DepartmentViewModel> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            var departmentViewModel = new DepartmentViewModel()
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name
            };
            return departmentViewModel;
        }

        public async Task UpdateAsync(DepartmentViewModel UpdatedDepartment)
        {
            var department = await _context.Departments.FindAsync(UpdatedDepartment.DepartmentId);
            department.Name = UpdatedDepartment.Name;

            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }
    }
}
