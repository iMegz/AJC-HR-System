using HR_System.Models;

namespace HR_System.Controllers
{
    public class EmployeeController : BaseController<Employee>
    {
        public EmployeeController(HRSystemDbContext context):base(context, "Employee")
        {
        }
    }
}
