using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystemManagement2.Data.Models
{
    public class EmployeeAttendanceModel
    {
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public DateTime ClockIn { get; set; }

        public DateTime? ClockOut { get; set; }

        // Navigation property to the employee
        public EmployeeTableModel? Employee { get; set; }
    }
}
