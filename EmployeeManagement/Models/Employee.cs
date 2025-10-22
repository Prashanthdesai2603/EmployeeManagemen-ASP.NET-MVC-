using System;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }     // PK
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public decimal? Salary { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
