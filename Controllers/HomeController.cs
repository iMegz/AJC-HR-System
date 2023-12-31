using HR_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HR_System.Controllers
{
    public class DashboardStats
    {
        public int Jobs { get; set; }

        public int Employees { get; set; }

        public int Applicants { get; set; }


    }


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HRSystemDbContext _context;

        public HomeController(ILogger<HomeController> logger, HRSystemDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            // Awaits
            int jobsCount = await _context.Jobs.CountAsync();
            int employeesCount = await _context.Employees.CountAsync();
            int applicantsCount = await _context.Applicants.CountAsync();

            DashboardStats stats = new DashboardStats
            {
                Jobs = jobsCount,
                Employees = employeesCount,
                Applicants = applicantsCount
            };

            return View(stats);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
