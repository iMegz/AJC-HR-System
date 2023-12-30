using HR_System.Models;

namespace HR_System.Controllers
{
    public class JobsController : BaseController<Job>
    {
        public JobsController(HRSystemDbContext context):base(context, "Job")
        {
        }
    }
}
