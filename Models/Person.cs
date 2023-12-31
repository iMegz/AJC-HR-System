using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Models
{
    public abstract class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public float? Salary { get; set; }


        [ForeignKey("Job")]
        public int JobId { get; set; }

        public virtual Job? Job { get; set; }

    }
}
