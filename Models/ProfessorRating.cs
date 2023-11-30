using System.Security.Principal;

namespace MyRateApp2.Models
{
    public class ProfessorRating
    {
        public int ProfessorRatingId { get; set; }
        public int Awesome { get; set; }
        public int Great { get; set; }
        public int Awful { get; set; }
        public int Good { get; set; }
        public int Ok { get; set; }
        public string? Comments { get; set; }
        public bool Attendance { get; set; }
        public float Grade { get; set; }
        public bool Textbook { get; set; }
        public DateTime Date { get; set; }
        public int RatingQuality { get; set; }
        public int RatingDificulty { get; set; }
        public bool WouldTakeAgain { get; set; }
        public bool ForCredit { get; set; }

        // Foreign Key to UserId
        public int UserId { get; set; }
        // Navigation Property
        public virtual User? User { get; set; }

        // Foreign Key to ProfessorId
        public int ProfId { get; set; }
        //Navigation Property
        public virtual Professor? Professor { get; set; }
    }
}
