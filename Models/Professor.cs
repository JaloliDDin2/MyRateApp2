using System.ComponentModel.DataAnnotations;

namespace MyRateApp2.Models
{
    public class Professor
    {
        [Key]
        public int ProfId { get; set; }
        public string? Fname { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? UniName { get; set; }
        public int UniId { get; set; }
        public virtual University University { get; set; }
        public virtual ICollection<ProfessorRating> ProfessorRatings { get; set; }

        
    }
}
