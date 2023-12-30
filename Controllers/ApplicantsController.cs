using HR_System.Models;

namespace HR_System.Controllers
{
    public class ApplicantsController : BaseController<Applicant>
    {

        public ApplicantsController(HRSystemDbContext context):base(context, "Applicant")
        {
            
        }
    }
}
