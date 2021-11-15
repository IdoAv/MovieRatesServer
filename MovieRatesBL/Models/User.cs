using System;
using System.Collections.Generic;

#nullable disable

namespace MovieRatesBL.Models
{
    public partial class User
    {
        public User()
        {
            Entries = new HashSet<Entry>();
            FollowingUserFollowerUsers = new HashSet<FollowingUser>();
            FollowingUserFollowingUserNavigations = new HashSet<FollowingUser>();
            LikedMovies = new HashSet<LikedMovie>();
            Ratings = new HashSet<Rating>();
            ReviewComments = new HashSet<ReviewComment>();
            Reviews = new HashSet<Review>();
            UsersReviews = new HashSet<UsersReview>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int FavGenreId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime SignUpDate { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
        public virtual ICollection<FollowingUser> FollowingUserFollowerUsers { get; set; }
        public virtual ICollection<FollowingUser> FollowingUserFollowingUserNavigations { get; set; }
        public virtual ICollection<LikedMovie> LikedMovies { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<ReviewComment> ReviewComments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<UsersReview> UsersReviews { get; set; }
    }
}
