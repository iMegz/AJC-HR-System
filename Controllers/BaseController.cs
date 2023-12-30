using HR_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Controllers
{
    public abstract class BaseController<T> : Controller where T: class
    {
        private readonly HRSystemDbContext _context;
        private readonly string _notFoundType;

        public BaseController(HRSystemDbContext context, string notFoundType = "Page")
        {
            _context = context;
            _notFoundType = notFoundType;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<T> entries = (from entry in _context.Set<T>() select entry).ToList();
            return View(entries);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View("Entry");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            T? entry = (from e in _context.Set<T>() where EF.Property<int>(e, "Id") == id select e).FirstOrDefault();
            if (entry != null)
            {
                return View("Entry", entry);
            }
            TempData["isError"] = true;
            return View("NotFound", _notFoundType);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            T? entry = (from e in _context.Set<T>() where EF.Property<int>(e, "Id") == id select e).FirstOrDefault();
            if (entry != null)
            {
                _context.Set<T>().Remove(entry);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult PostAdd(T entry)
        {
            _context.Set<T>().Add(entry);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult PostEdit(T entry)
        {
            int? Id = entry.GetType().GetProperty("Id")?.GetValue(entry) as int?;

            T? exists = (from e in _context.Set<T>() where EF.Property<int>(e, "Id") == Id select e).FirstOrDefault();
            if (exists != null)
            {
                _context.Entry(exists).CurrentValues.SetValues(entry);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
