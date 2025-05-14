using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystemManagement2.Data.Models
{
    public class EmployeeTableModel
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime HireDate { get; set; }
        public string Salary { get; set; }
        public string Bonus { get; set; }
        public string? Position { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }  
        public string? Status { get; set; }

        public EmployeeTableModel(int employeeId, string firstName, string lastName, DateTime hireDate, string salary, string bonus, string position , DateTime checkInTime, DateTime checkOutTime, string status)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            HireDate = hireDate;
            Salary = salary;
            Bonus = bonus;
            Position = position;
            CheckInTime = checkInTime;
            CheckOutTime = checkOutTime;
            Status = status;
        }

        public EmployeeTableModel()
        {

        }
       
    }

}
/*EmployeeId] [int] IDENTITY(1,1) NOT NULL,

    [EmployeeFisrtName] [nvarchar] (50) NULL,

    [EmployeeLastName] [nvarchar] (50) NULL,

    [HireDate] [datetime] NOT NULL,

    [Salary] [nvarchar] (25) NOT NULL,

    [Bonus] [nvarchar] (25) NULL,

    [Position]*/