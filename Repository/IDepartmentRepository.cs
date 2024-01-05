using Employee_Tracker.Models;
using Employee_Tracker.ViewModel;

namespace Employee_Tracker.Repository
{
    public interface IDepartmentRepository
    {
        Task<DepartmentViewModel> GetDepartmentByIdAsync(int id);

        Task<List<DepartmentViewModel>> GetAllDepartmentListAsync();

        Task AddSync(DepartmentViewModel department);

        Task DeleteAsync(int id);

        Task UpdateAsync(DepartmentViewModel department);
    }
}
