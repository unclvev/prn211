using System;
using System.Collections.Generic;

namespace prn211.Models
{
    public partial class CourseOwner
    {
        public CourseOwner()
        {
            Courses = new HashSet<Course>();
        }

        public int Ownerid { get; set; }
        public int Userid { get; set; }
        public DateTime? Beownerdob { get; set; }
        public string? Aboutme { get; set; }
        public string? Major { get; set; }
        public string? Phone { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; set; }
    }
}
