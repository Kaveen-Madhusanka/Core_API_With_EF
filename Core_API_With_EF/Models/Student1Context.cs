using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Core_API_With_EF.Models
{
    public partial class Student1Context : DbContext
    {
        public Student1Context()
        {
        }

        public Student1Context(DbContextOptions<Student1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<TblStudent> TblStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=DESKTOP-7NPAUSD\\SQLEXPRESS;Database=Student1;User ID=sa;Password=compaq123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.Userid);

                entity.ToTable("login");

                entity.Property(e => e.Userid)
                    .ValueGeneratedNever()
                    .HasColumnName("userid");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("tblStudent");

                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.StudentAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentGender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
