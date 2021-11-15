using System;
using System.Collections.Generic;

#nullable disable

namespace MovieRatesBL.Models
{
    public partial class Review
    {
        public Review()
        {
            ReviewComments = new HashSet<ReviewComment>();
            UsersReviews = new HashSet<UsersReview>();
        }

        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string ReviewContent { get; set; }
        public DateTime ReviewTime { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ReviewComment> ReviewComments { get; set; }
        public virtual ICollection<UsersReview> UsersReviews { get; set; }
    }
}
