using System.ComponentModel.DataAnnotations;

namespace Employee_Tracker.ViewModel
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage ="Department is required...!!!")]
        public string Name { get; set; }
    }
}
