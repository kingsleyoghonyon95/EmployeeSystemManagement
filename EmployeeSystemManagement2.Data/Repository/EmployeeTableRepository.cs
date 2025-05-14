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
        private EmployeeDBContext _dbContext;

        public EmployeeTableRepository(EmployeeDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(EmployeeTableModel employee)
        {

            _dbContext.Add(employee);
            _dbContext.SaveChanges();

            return employee.EmployeeId;
        }

        public int Update(EmployeeTableModel employee)
        {
            EmployeeTableModel existingEmployee = _dbContext.EmployeeTable.Find(employee.EmployeeId)!;

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.HireDate = employee.HireDate;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Bonus = employee.Bonus;
            existingEmployee.Position = employee.Position;
            existingEmployee.CheckInTime = employee.CheckInTime;
            existingEmployee.CheckOutTime = employee.CheckOutTime;
            existingEmployee.Status = employee.Status;
            

            _dbContext.SaveChanges();

            return existingEmployee.EmployeeId;
        }

        public bool Delete(int employeeID)
        {
            EmployeeTableModel employee = _dbContext.EmployeeTable.Find(employeeID)!;
            _dbContext.Remove(employee);
            _dbContext.SaveChanges();
                
            return true;
        }

        public List<EmployeeTableModel> GetAllEmployeeSystemManagement()
        {
            List<EmployeeTableModel> employeeSystemManagementList = _dbContext.EmployeeTable.ToList();

            return employeeSystemManagementList;
        }

        public EmployeeTableModel GetEmployeeSystemManagementByID(int employeeID)
        {
            EmployeeTableModel employee = _dbContext.EmployeeTable.Find(employeeID)!;

            return employee;
        }
    }
}


