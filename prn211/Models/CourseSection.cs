using System;
using System.Collections.Generic;

namespace prn211.Models
{
    public partial class CourseSection
    {
        public CourseSection()
        {
            CourseContents = new HashSet<CourseContent>();
        }

        public int SectionId { get; set; }
        public int Courseid { get; set; }
        public int? Sectionorder { get; set; }
        public DateTime? Sectiondob { get; set; }
        public string? Sectiontitle { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual ICollection<CourseContent> CourseContents { get; set; }
    }
}
