using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeSystemManagement2.Data.Models;
using EmployeeSystemManagement2.Data.Context;

namespace EmployeeSystemManagement2.Data.Repository
{
    public class EmployeeTableRepository
    {
        private readonly EmployeeDBContext _dbContext;

        public EmployeeTableRepository(EmployeeDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(EmployeeTableModel employee)
        {
            _dbContext.EmployeeTable.Add(employee);
            _dbContext.SaveChanges();
            return employee.EmployeeId;
        }

        public int Update(EmployeeTableModel employee)
        {
            var existingEmployee = _dbContext.EmployeeTable.Find(employee.EmployeeId)!;

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.HireDate = employee.HireDate;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Bonus = employee.Bonus;
            existingEmployee.Position = employee.Position;


            _dbContext.SaveChanges();
            return existingEmployee.EmployeeId;
        }

        public bool Delete(int employeeID)
        {
            var employee = _dbContext.EmployeeTable.Find(employeeID)!;
            _dbContext.EmployeeTable.Remove(employee);
            _dbContext.SaveChanges();
            return true;
        }

        public List<EmployeeTableModel> GetAllEmployeeSystemManagement()
        {
            return _dbContext.EmployeeTable
                .Include(e => e.AttendanceRecords) 
                .ToList();
        }

        public EmployeeTableModel GetEmployeeSystemManagementByID(int employeeID)
        {
            return _dbContext.EmployeeTable
                .Include(e => e.AttendanceRecords)
                .FirstOrDefault(e => e.EmployeeId == employeeID)!;
        }
    }
}

