using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Tracker.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        // Navigating Properties

        [ForeignKey("Department")]
        public int DepartmentId { get; set; } // Foreign key

        public Department Department { get; set; } // navigating property


    }
}
