using EmployeeSystemManagement2.Data.Context;
using EmployeeSystemManagement2.Data.Models;
using EmployeeSystemManagementWebApp2.Models;
using Microsoft.AspNetCore.Mvc;

public class EmployeeTableController : Controller
{
    private readonly EmployeeDBContext _dBContext;

    public EmployeeTableController(EmployeeDBContext dBContext)
    {
        _dBContext = dBContext;
    }

    public IActionResult Index(string? actionMessage = null, bool isSuccess = true)
    {
        EmployeeViewModel model = new(_dBContext)
        {
            ActionMessage = actionMessage,
            IsActionSuccess = isSuccess
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Save(int employeeId, string firstName, string lastName, DateTime hireDate, string salary, string bonus, string position, DateTime checkInTime, DateTime checkOutTime, string status)
    {
        EmployeeViewModel model = new(_dBContext);
        EmployeeTableModel modelTable = new(employeeId, firstName, lastName, hireDate, salary, bonus, position, checkInTime, checkOutTime, status);

        model.SaveEmployee(modelTable);

        return RedirectToAction("Index", new
        {
            actionMessage = "Employee has been saved",
            isSuccess = true
        });
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

        return RedirectToAction("Index", new
        {
            actionMessage = "Employee has been deleted successfully",
            isSuccess = true
        });
    }
}
