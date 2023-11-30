using System.ComponentModel.DataAnnotations;

namespace MyRateApp2.Models
{
    public class UniverRating
    {
        [Key]
        public int UniRatingId { get; set; }


        // Foreign Key to UserId
        public int UserId { get; set; }
        // Navigation Property
        public virtual User? User { get; set; }

        // Foreign Key to UserId
        public int UniId { get; set; }
        //Navigation Property
        public virtual University? University { get; set; }

        public int Reputation { get; set; }
        public int Happiness { get; set; }
        public int Safety { get; set; }
        public int Opportunities { get; set; }
        public int Facilities { get; set; }
        public int Clubs { get; set; }
        public int Internet { get; set; }
        public int Location { get; set; }
        public int Social { get; set; }
        public int Food { get; set; }
        public DateTime Date { get; set; }
        public string? Comment { get; set; }
        public float OverallRating { get; set; }

    }
}
