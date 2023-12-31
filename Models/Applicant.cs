using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Models
{
    public enum ApplicantStatus
    {
        UnReviewed,
        WaitingListed,
        Accepted,
        Rejected
    }

    public enum MilitaryStatus
    {
        Completed,
        Exempted,
        Postponed,
        NA_Females
    }

    public class Applicant : Person
    {

        public MilitaryStatus MilitaryStatus { get; set; }

        public string? CV { get; set; }

        public ApplicantStatus applicantStatus { get; set; }
    }
}
