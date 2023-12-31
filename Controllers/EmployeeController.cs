using HR_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Controllers
{
    public class EmployeeViewModel
    {
        public Employee? Employee { get; set; }
        public List<Job>? Jobs { get; set; }
    }

    public class EmployeeController : Controller
    {
        private readonly HRSystemDbContext _context;

        public EmployeeController(HRSystemDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<Employee> employees = (from employee in _context.Employees.Include("Job") select employee).ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Job> jobs = (from j in _context.Jobs select j).ToList();

            EmployeeViewModel employeeViewModel = new()
            {
                Jobs = jobs
            };
            return View("Entry", employeeViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            Employee? employee = (from e in _context.Employees where e.Id == id select e).FirstOrDefault();
            List<Job> jobs = (from j in _context.Jobs select j).ToList();

            EmployeeViewModel employeeViewModel = new()
            {
                Employee = employee,
                Jobs = jobs
            };

            if (employee != null)
            {
                return View("Entry", employeeViewModel);
            }
            TempData["isError"] = true;
            return View("NotFound", "Employee");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee? employee = (from e in _context.Employees where e.Id == id select e).FirstOrDefault();
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult PostAdd(Employee employee)
        {
            //Job job = (from j in _context.Jobs where j.JobId == employee.JobId select j).FirstOrDefault()!;
            //job.People!.Add(employee);
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult PostEdit(Employee employee)
        {
            Employee? oldEmployee = (from e in _context.Employees where e.Id == employee.Id select e).FirstOrDefault();
            if (oldEmployee != null)
            {
                _context.Entry(oldEmployee).State = EntityState.Detached;
                _context.Update(employee);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}
