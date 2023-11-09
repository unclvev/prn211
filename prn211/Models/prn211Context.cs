using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace prn211.Models
{
    public partial class prn211Context : DbContext
    {
        public prn211Context()
        {
        }

        public prn211Context(DbContextOptions<prn211Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseContent> CourseContents { get; set; } = null!;
        public virtual DbSet<CourseOwner> CourseOwners { get; set; } = null!;
        public virtual DbSet<CourseSection> CourseSections { get; set; } = null!;
        public virtual DbSet<Enroll> Enrolls { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =DESKTOP-30PABEK\\SANCHOI; database = prn211;uid=sa;pwd=viet2982003;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.Courseid).HasColumnName("courseid");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Coursename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("coursename");

                entity.Property(e => e.Createdate)
                    .HasPrecision(6)
                    .HasColumnName("createdate");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Ownerid).HasColumnName("ownerid");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Ownerid)
                    .HasConstraintName("FK__course__ownerid__24285DB4");
            });

            modelBuilder.Entity<CourseContent>(entity =>
            {
                entity.HasKey(e => e.ContentId)
                    .HasName("PK__courseCo__655FE51012460C7A");

                entity.ToTable("courseContent");

                entity.Property(e => e.ContentId).HasColumnName("content_id");

                entity.Property(e => e.Contentdob)
                    .HasPrecision(6)
                    .HasColumnName("contentdob");

                entity.Property(e => e.Contentorder).HasColumnName("contentorder");

                entity.Property(e => e.Contenttitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("contenttitle");

                entity.Property(e => e.Coursesectionid).HasColumnName("coursesectionid");

                entity.Property(e => e.Ispublic).HasColumnName("ispublic");

                entity.Property(e => e.Linkvideo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("linkvideo");

                entity.HasOne(d => d.Coursesection)
                    .WithMany(p => p.CourseContents)
                    .HasForeignKey(d => d.Coursesectionid)
                    .HasConstraintName("FK_courseContent_courseSection");
            });

            modelBuilder.Entity<CourseOwner>(entity =>
            {
                entity.HasKey(e => e.Ownerid)
                    .HasName("PK__courseOw__7E4A4D644068EE4F");

                entity.ToTable("courseOwner");

                entity.Property(e => e.Ownerid).HasColumnName("ownerid");

                entity.Property(e => e.Aboutme)
                    .HasColumnType("text")
                    .HasColumnName("aboutme");

                entity.Property(e => e.Beownerdob)
                    .HasPrecision(6)
                    .HasColumnName("beownerdob");

                entity.Property(e => e.Major)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("major");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseOwners)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__courseOwn__useri__214BF109");
            });

            modelBuilder.Entity<CourseSection>(entity =>
            {
                entity.HasKey(e => e.SectionId)
                    .HasName("PK__courseSe__F842676A3D77E61C");

                entity.ToTable("courseSection");

                entity.Property(e => e.SectionId).HasColumnName("section_id");

                entity.Property(e => e.Courseid).HasColumnName("courseid");

                entity.Property(e => e.Sectiondob)
                    .HasPrecision(6)
                    .HasColumnName("sectiondob");

                entity.Property(e => e.Sectionorder).HasColumnName("sectionorder");

                entity.Property(e => e.Sectiontitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("sectiontitle");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseSections)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_courseSection_course");
            });

            modelBuilder.Entity<Enroll>(entity =>
            {
                entity.ToTable("enroll");

                entity.Property(e => e.Enrollid).HasColumnName("enrollid");

                entity.Property(e => e.Courseid).HasColumnName("courseid");

                entity.Property(e => e.Processstatus).HasColumnName("processstatus");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrolls)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__enroll__courseid__2DB1C7EE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Enrolls)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__enroll__userid__2CBDA3B5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("avatar");

                entity.Property(e => e.Dob)
                    .HasPrecision(6)
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Isenabled).HasColumnName("isenabled");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Registerdob)
                    .HasColumnType("date")
                    .HasColumnName("registerdob");

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
