using EmployeeSystemManagement2.Data.Context;
using EmployeeSystemManagement2.Data.Models;
using EmployeeSystemManagement2.Data.Repository;

namespace EmployeeSystemManagementWebApp2.Models
{
    public class EmployeeViewModel
    {
        private EmployeeTableRepository _repo;

        public List<EmployeeTableModel> EmployeeList { get; set; }

        public EmployeeTableModel? CurrentEmployeeTable { get; set; }

        public bool IsActionSuccess { get; set; }

        public string? ActionMessage { get; set; }

        public EmployeeViewModel(EmployeeDBContext context)
        {
            _repo = new EmployeeTableRepository(context);
            EmployeeList = GetAllEmployees();
            CurrentEmployeeTable = EmployeeList.FirstOrDefault();
        }

        public EmployeeViewModel(EmployeeDBContext context, int employeeId)
        {
            _repo = new EmployeeTableRepository(context);
            EmployeeList = GetAllEmployees();

            if (employeeId > 0)
            {
                CurrentEmployeeTable = GetEmployee(employeeId);
            }
            else
            {
                CurrentEmployeeTable = new EmployeeTableModel();
            }
        }

        public void SaveEmployee(EmployeeTableModel employee)
        {
            if (employee.EmployeeId > 0)
            {
                _repo.Update(employee);
            }
            else
            {
                employee.EmployeeId = _repo.Create(employee);
            }

            EmployeeList = GetAllEmployees();
            CurrentEmployeeTable = GetEmployee(employee.EmployeeId);
        }

        public void RemoveEmployee(int employeeID)
        {
            _repo.Delete(employeeID);
            EmployeeList = GetAllEmployees();
            CurrentEmployeeTable = EmployeeList.FirstOrDefault();
        }

        public List<EmployeeTableModel> GetAllEmployees()
        {
            return _repo.GetAllEmployeeSystemManagement();
        }

        public EmployeeTableModel GetEmployee(int employeeId)
        {
            return _repo.GetEmployeeSystemManagementByID(employeeId);
        }




    }
}
