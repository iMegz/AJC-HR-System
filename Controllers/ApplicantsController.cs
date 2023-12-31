using HR_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Controllers
{
    public class ApplicantsController : Controller
    {
        private readonly HRSystemDbContext _context;

        public ApplicantsController(HRSystemDbContext context)
        {
            _context = context;
        }
    }
}
