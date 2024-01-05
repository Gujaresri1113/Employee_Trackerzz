namespace Employee_Tracker.Models
{
    public class Department
    {
        ///primary key
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        //Navigation Property
        public ICollection<Employee> Employees { get; set;} // collection NP
    }
}
