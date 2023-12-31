using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Models
{
    public class Job
    {
        public Job()
        {
            People = new List<Person>();
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        public string? Title { get; set; }


        public string? Description { get; set; }

        public DateTime OpenUntil { get; set; }

        public ICollection<Person>? People { get; set; }

    }
}
