using System;
using System.Collections.Generic;
using Web_Api.Data;

namespace Web_Api.Models
{
    public partial class Employee : Auditable
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public long EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
