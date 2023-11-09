using System;
using System.Collections.Generic;

namespace prn211.Models
{
    public partial class User
    {
        public User()
        {
            CourseOwners = new HashSet<CourseOwner>();
            Enrolls = new HashSet<Enroll>();
        }

        public int Userid { get; set; }
        public bool? Gender { get; set; }
        public bool? Isenabled { get; set; }
        public DateTime? Registerdob { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public string? Email { get; set; }
        public string? Fullname { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Username { get; set; }

        public virtual ICollection<CourseOwner> CourseOwners { get; set; }
        public virtual ICollection<Enroll> Enrolls { get; set; }
    }
}
