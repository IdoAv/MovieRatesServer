using System;
using System.Collections.Generic;

#nullable disable

namespace MovieRatesBL.Models
{
    public partial class LikedMovie
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public bool IsLiked { get; set; }

        public virtual User User { get; set; }
    }
}
