using System;
using System.Collections.Generic;

namespace prn211.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseSections = new HashSet<CourseSection>();
            Enrolls = new HashSet<Enroll>();
        }

        public int? Categoryid { get; set; }
        public int Courseid { get; set; }
        public int? Ownerid { get; set; }
        public DateTime? Createdate { get; set; }
        public string? Coursename { get; set; }
        public string? Image { get; set; }

        public virtual CourseOwner? Owner { get; set; }
        public virtual ICollection<CourseSection> CourseSections { get; set; }
        public virtual ICollection<Enroll> Enrolls { get; set; }
    }
}
