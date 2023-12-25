using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Models
{
    public class Employee : Person
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
