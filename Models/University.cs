using System.ComponentModel.DataAnnotations;

namespace MyRateApp2.Models
{
    public class University
    {
        [Key]
        public int UniId { get; set; }
        public string? UniName { get; set; }

        public string? UniCountry { get; set; }
        public string? UniState { get; set; }
        public string? UniWebsite { get; set; }
        public string? UniEmail { get; set; }

        public virtual ICollection<Professor>? Professors { get; set; }
        public virtual ICollection<UniverRating>? UniversityRatings { get; set; }
    }
}
