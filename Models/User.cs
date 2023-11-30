using Microsoft.AspNetCore.Components.Routing;

namespace MyRateApp2.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? School { get; set; }
        public string? Email { get; set; }
        public int GraduateYear{ get; set; }
        public string? Password { get; set; }

        public virtual ICollection<UniverRating>? UniverRatings { get; set; }
        public virtual ICollection<ProfessorRating>? ProfessorRatings { get; set; }

        // METHOD TO GET RATINGS PROVIDED BY USER
        public IEnumerable<Rating> GetUserRatings()
        {
            var userRatings = new List<Rating>();
            if (UniverRatings != null)
            {
                foreach (var univerRating in UniverRatings)
                {
                    userRatings.Add(new Rating
                    {
                        RatingID = univerRating.UniRatingId,
                        EntityID = univerRating.UniId,
                        EntityType = RatingEntityType.University,
                        RatingValue = univerRating.OverallRating,
                        Comments = univerRating.Comment,
                        Timestamp = univerRating.Date,
                        Reputation = univerRating.Reputation,
                        Happiness = univerRating.Happiness,
                        Safety = univerRating.Safety,
                        Clubs = univerRating.Clubs,
                        Opportunities = univerRating.Opportunities,
                        Facilities = univerRating.Facilities,
                        Internet = univerRating.Internet,
                        Location = univerRating.Location,
                        Social = univerRating.Social,
                        Food = univerRating.Food,

                    });
                }
            }
            if (ProfessorRatings != null)
            {
                foreach (var professorRating in ProfessorRatings)
                {
                    userRatings.Add(new Rating
                    {
                        RatingID = professorRating.ProfessorRatingId,    
                        EntityID = professorRating.ProfId,
                        EntityType = RatingEntityType.Professor,
                        RatingQuality = professorRating.RatingQuality,
                        RatingDificulty = professorRating.RatingDificulty,
                        Comments = professorRating.Comments,
                        Timestamp = professorRating.Date,
                        Attendance = professorRating.Attendance,
                        WouldTakeAgain = professorRating.WouldTakeAgain,
                        Grade = professorRating.Grade,
                        Textbook = professorRating.Textbook,
                        ForCredit = professorRating.ForCredit
                    });
                }
            }

            return userRatings;
        }

    }
    public class Rating
    {
        public int RatingID { get; set; }
        public int EntityID { get; set; }
        public RatingEntityType EntityType { get; set; }
        public string? Comments { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Attendance { get; set; }
        public bool WouldTakeAgain { get; set; }
        public float Grade { get; set; }
        public bool Textbook { get; set; }
        public bool ForCredit { get; set; }
        public float RatingQuality { get; set; }
        public float RatingDificulty { get; set; }
        public float RatingValue { get; set; }
        public int Reputation { get; set; }
        public int Happiness { get; set; }
        public int Safety { get; set; }
        public int Clubs { get; set; }
        public int Opportunities { get; set; }
        public int Facilities { get; set; }
        public int Internet { get; set; }
        public int Location { get; set; }
        public int Social { get; set; }
        public int Food { get; set; }


    }
    public enum RatingEntityType
    {
        University,
        Professor
    }
}
