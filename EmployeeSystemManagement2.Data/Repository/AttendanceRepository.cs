using EmployeeSystemManagement2.Data.Context;
using EmployeeSystemManagement2.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeSystemManagement2.Data.Repository
{
    public class AttendanceRepository
    {
        private readonly EmployeeDBContext _dbContext;

        public AttendanceRepository(EmployeeDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add a new attendance record
        public void AddAttendance(EmployeeAttendanceModel attendance)
        {
            if (attendance != null)
            {
                _dbContext.EmployeeAttendance.Add(attendance);
                _dbContext.SaveChanges();
            }
        }

        // Update an existing attendance record
        public void UpdateAttendance(EmployeeAttendanceModel attendance)
        {
            if (attendance != null)
            {
                _dbContext.EmployeeAttendance.Update(attendance);
                _dbContext.SaveChanges();
            }
        }

        // Get all attendance records for a specific employee
        public List<EmployeeAttendanceModel> GetAttendanceByEmployeeId(int employeeId)
        {
            return _dbContext.EmployeeAttendance
                             .Include(a => a.Employee) // ✅ include navigation property
                             .Where(a => a.EmployeeId == employeeId)
                             .ToList();
        }

        // Optional: Get a single attendance record by ID
        public EmployeeAttendanceModel? GetById(int id)
        {
            return _dbContext.EmployeeAttendance
                             .Include(a => a.Employee)
                             .FirstOrDefault(a => a.Id == id);
        }

        // Optional: Get all records (for officers)
        public List<EmployeeAttendanceModel> GetAll()
        {
            return _dbContext.EmployeeAttendance
                             .Include(a => a.Employee)
                             .ToList();
        }
    }
}
