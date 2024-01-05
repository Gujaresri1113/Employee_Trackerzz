using Employee_Tracker.Models;
using Employee_Tracker.ViewModel;

namespace Employee_Tracker.Repository
{
    public interface IEmployeeRepository
    {
        Task<EmployeeViewModel> GetByIdAsync(int id);

        IQueryable<EmployeeViewModel> GetAllAsync();

        Task AddAsync(EmployeeViewModel employee);

        Task UpdateAsync(EmployeeViewModel employee);

        Task DeleteAsync(int id);

        Task<List<Department>> GetAllDepartment();
    }
}
