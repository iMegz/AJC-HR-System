namespace HR_System.Models
{
    public enum MilitaryStatus
    {
        Completed,
        Exempted,
        Postponed,
        NA_Females,
    }

    public class Applicant : Person
    {
        public MilitaryStatus MilitaryStatus { get; set; }

        public string? CV { get; set; }
    }
}
