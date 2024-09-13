using EmployeeSystemManagement2.Data.Context;
using EmployeeSystemManagement2.Data.Models;
using EmployeeSystemManagementWebApp2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystemManagementWebApp2.Controllers
{
    public class EmployeeTableController : Controller
    {
        private readonly EmployeeDBContext _dBContext;

        public EmployeeTableController(EmployeeDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IActionResult Index()
        {
            EmployeeViewModel model = new(_dBContext);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int employeeId, string firstName, string lastName, DateTime hireDate, string salary, string bonus, string position  )
        {
            EmployeeViewModel model = new(_dBContext);
            
            EmployeeTableModel modelTable = new EmployeeTableModel(employeeId, firstName, lastName, hireDate, salary, bonus, position );

            model.SaveEmployee(modelTable);
            model.IsActionSuccess = true;
            model.ActionMessage = "Employee has been saved";

            return View("Index", model);

        }

        public IActionResult Update(int id)
        {
            EmployeeViewModel model = new(_dBContext, id);
            return View(model);

        }

        public IActionResult Delete(int id)
        {
            EmployeeViewModel model = new(_dBContext);

            if (id > 0)
            {
                model.RemoveEmployee(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "Employee has been deleted sucessfully";
            return View("Index", model);
        }
        
         
    }
}
