using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_StoredProcedures.EmployeePayrollProblem
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public long PhoneNo { get; set; }
        public string EmployeeAddress { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }

    }
}
