using EmployeeSystemManagement2.Data.Models;
using System;
using System.Collections.Generic;

namespace EmployeeSystemManagement2.Data.Models
{
    public class EmployeeTableModel
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime HireDate { get; set; }

        public string Salary { get; set; } = string.Empty;
        public string Bonus { get; set; } = string.Empty;
        public string? Position { get; set; }
       

        public ICollection<EmployeeAttendanceModel>? AttendanceRecords { get; set; }

        public EmployeeTableModel() { }

        public EmployeeTableModel(int employeeId, string firstName, string lastName, DateTime hireDate, string salary, string bonus, string? position)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            HireDate = hireDate;
            Salary = salary;
            Bonus = bonus;
            Position = position;
           
        }
    }
}
