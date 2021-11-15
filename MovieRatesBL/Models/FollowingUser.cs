using System;
using System.Collections.Generic;

#nullable disable

namespace MovieRatesBL.Models
{
    public partial class FollowingUser
    {
        public int FollowerUserId { get; set; }
        public int FollowingUserId { get; set; }

        public virtual User FollowerUser { get; set; }
        public virtual User FollowingUserNavigation { get; set; }
    }
}
