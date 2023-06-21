using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_1
{
    public class Employee
    {
        public string EmployeeName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? IdentityIssuedDate { get; set; }
        public string? IdentityIssuedPlace { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? PositionName { get; set; }
        public string? DepartmentName { get; set; }
        public string? TaxCode { get; set; }
        public double? Salary { get; set; }
        public DateTime? JoiningDate { get; set; }
        public int? WorkStatus { get; set; }
    }
}