using System;
using System.Collections.Generic;

#nullable disable

namespace MovieRatesBL.Models
{
    public partial class Entry
    {
        public int EntryId { get; set; }
        public int UserId { get; set; }
        public DateTime EntryTime { get; set; }

        public virtual User User { get; set; }
    }
}
