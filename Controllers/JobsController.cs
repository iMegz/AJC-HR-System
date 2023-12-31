using HR_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Controllers
{
    public class JobsController : Controller
    {
        private readonly HRSystemDbContext _context;

        public JobsController(HRSystemDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Job> jobs = (from job in _context.Jobs select job).ToList();
            return View(jobs);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View("Entry");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Job? job = (from j in _context.Jobs where j.JobId == id select j).FirstOrDefault();
            if (job != null)
            {
                return View("Entry", job);
            }
            TempData["isError"] = true;
            return View("NotFound", "Job");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Job? job = (from j in _context.Jobs where j.JobId == id select j).FirstOrDefault();
            if (job != null)
            {
                _context.Jobs.Remove(job);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult PostAdd(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult PostEdit(Job job)
        {
            Job? oldJob = (from j in _context.Jobs where j.JobId == job.JobId select j).FirstOrDefault();
            if (oldJob != null)
            {
                _context.Entry(oldJob).CurrentValues.SetValues(job);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // FOR TESTING
        public IActionResult PeopleCount(int id)
        {
            Job? job = (from j in _context.Jobs where j.JobId != id select j).FirstOrDefault();
            return Json(new { size = job.People.Count });
        }
    }
}