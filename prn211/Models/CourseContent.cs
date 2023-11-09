using System;
using System.Collections.Generic;

namespace prn211.Models
{
    public partial class CourseContent
    {
        public int ContentId { get; set; }
        public int? Contentorder { get; set; }
        public int? Coursesectionid { get; set; }
        public bool? Ispublic { get; set; }
        public DateTime? Contentdob { get; set; }
        public string? Contenttitle { get; set; }
        public string? Linkvideo { get; set; }

        public virtual CourseSection? Coursesection { get; set; }
    }
}
