using Employee_Tracker.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Tracker.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="First Name is required...!")]
        [StringLength(50, ErrorMessage = "First Name cannot Exceed more than 50 characters...")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name is required...!")]
        [StringLength(50, ErrorMessage ="Last Name can't exceed characters more than 50..")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Date of Birth is required...!")]
        [Display(Name ="Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage ="Please select the gender...!")]
        public string Gender { get; set; }

        [Required(ErrorMessage ="Email address is required...!")]
        [EmailAddress(ErrorMessage ="Invalid email, check @ ...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required..!")]
        [Phone(ErrorMessage = " Invalid Phone Number...")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Address is required...!")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Check the status...!")]
        public bool IsActive { get; set; }

        //Relationship with department
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}
