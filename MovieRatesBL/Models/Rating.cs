﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MovieRatesBL.Models
{
    public partial class Rating
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public double Rating1 { get; set; }

        public virtual User User { get; set; }
    }
}
