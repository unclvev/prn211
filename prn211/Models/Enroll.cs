using System;
using System.Collections.Generic;

namespace prn211.Models
{
    public partial class Enroll
    {
        public int Courseid { get; set; }
        public int Userid { get; set; }
        public int Enrollid { get; set; }
        public bool? Processstatus { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
