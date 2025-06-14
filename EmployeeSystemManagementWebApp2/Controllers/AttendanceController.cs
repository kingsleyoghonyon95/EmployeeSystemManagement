using EmployeeSystemManagement2.Data.Context;
using EmployeeSystemManagement2.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeSystemManagementWebApp2.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly EmployeeDBContext _dbContext;

        public AttendanceController(EmployeeDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Attendance/Index?employeeId=123
        public async Task<IActionResult> Index(int? employeeId = null)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);

            if (userId == null || role == null)
                return Unauthorized();

            bool isOfficer = role == "Officer";
            List<EmployeeAttendanceModel> records;

            if (isOfficer)
            {
                ViewBag.EmployeeList = await _dbContext.EmployeeTable
                    .Select(e => new
                    {
                        e.EmployeeId,
                        FullName = e.FirstName + " " + e.LastName
                    })
                    .ToListAsync();

                records = await _dbContext.EmployeeAttendance
                    .Include(a => a.Employee)
                    .Where(a => !employeeId.HasValue || a.EmployeeId == employeeId.Value)
                    .ToListAsync();
            }
            else
            {
                if (!int.TryParse(userId, out int employeeIdParsed))
                    return Unauthorized();

                records = await _dbContext.EmployeeAttendance
                    .Include(a => a.Employee)
                    .Where(a => a.EmployeeId == employeeIdParsed)
                    .ToListAsync();
            }

            ViewBag.IsOfficer = isOfficer;
            return View(records);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role != "Officer") return Forbid();

            var attendance = await _dbContext.EmployeeAttendance
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (attendance == null)
                return NotFound();

            return View(attendance);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeAttendanceModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _dbContext.EmployeeAttendance.Update(model);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
