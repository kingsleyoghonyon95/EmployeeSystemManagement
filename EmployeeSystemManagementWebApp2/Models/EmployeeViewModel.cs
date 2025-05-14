using System.ComponentModel.DataAnnotations;
using EmployeeSystemManagement2.Data.Context;
using EmployeeSystemManagement2.Data.Models;
using EmployeeSystemManagement2.Data.Repository;

namespace EmployeeSystemManagementWebApp2.Models
{
    public class EmployeeViewModel
    {
        private readonly EmployeeTableRepository _repo;

        public List<EmployeeTableModel> EmployeeList { get; set; } = new();

        public EmployeeTableModel? CurrentEmployeeTable { get; set; }

        public bool IsActionSuccess { get; set; }

        public string? ActionMessage { get; set; }

        // -------------------
        // Validation Properties
        // -------------------

        [Required(ErrorMessage = "First name is required.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Hire date is required.")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Salary is required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Salary must be a valid number.")]
        public decimal Salary { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Bonus must be a valid number.")]
        public decimal Bonus { get; set; } 

        [Required(ErrorMessage = "Position is required.")]
        public string? Position { get; set; }

        [Required(ErrorMessage = "Check-in time is required.")]
        [DataType(DataType.Time)]
        public DateTime CheckInTime { get; set; } = DateTime.Today.AddHours(9); // Default 9 AM

        [Required(ErrorMessage = "Check-out time is required.")]
        [DataType(DataType.Time)]
        public DateTime CheckOutTime { get; set; } = DateTime.Today.AddHours(17); // Default 5 PM

        public string? Status { get; set; }

        // -------------------
        // Constructors
        // -------------------

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
            CurrentEmployeeTable = employeeId > 0
                ? GetEmployee(employeeId)
                : new EmployeeTableModel();
        }

        // -------------------
        // Repository Methods
        // -------------------

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
