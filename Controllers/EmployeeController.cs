using HR_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HRSystemDbContext _context;

        public EmployeeController(HRSystemDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();

            employees = (from  emp in _context.Employees  select emp).ToList();

            return View(employees);
        }


        public IActionResult Add()
        {


            return RedirectToAction("Index");
        }
    }
}
