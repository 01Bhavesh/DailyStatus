using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbFirstApproach.Models;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BatchStudent> BatchStudents { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseBatch> CourseBatches { get; set; }

    public virtual DbSet<CourseModule> CourseModules { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<FacultyAddress> FacultyAddresses { get; set; }

    public virtual DbSet<FacultyPhone> FacultyPhones { get; set; }

    public virtual DbSet<FacultyQualification> FacultyQualifications { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAddress> StudentAddresses { get; set; }

    public virtual DbSet<StudentCard> StudentCards { get; set; }

    public virtual DbSet<StudentOrder> StudentOrders { get; set; }

    public virtual DbSet<StudentPhone> StudentPhones { get; set; }

    public virtual DbSet<StudentQualification> StudentQualifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UJ0U9DN\\SQLEXPRESS; Database=data; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BatchStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__batch_st__3214EC276F8E2D87");

            entity.ToTable("batch_students");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.BatchId).HasColumnName("batchID");
            entity.Property(e => e.StudentId).HasColumnName("studentID");

            entity.HasOne(d => d.Batch).WithMany(p => p.BatchStudents)
                .HasForeignKey(d => d.BatchId)
                .HasConstraintName("FK__batch_stu__batch__71D1E811");

            entity.HasOne(d => d.Student).WithMany(p => p.BatchStudents)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__batch_stu__stude__72C60C4A");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__course__3214EC2772D073C3");

            entity.ToTable("course");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Summery)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasColumnName("summery");
        });

        modelBuilder.Entity<CourseBatch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__course_b__3214EC272BF70467");

            entity.ToTable("course_batches");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.CourseId).HasColumnName("courseID");
            entity.Property(e => e.Endson).HasColumnName("endson");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Starton).HasColumnName("starton");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseBatches)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__course_ba__cours__6EF57B66");
        });

        modelBuilder.Entity<CourseModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__course_m__3214EC27FE2BADC7");

            entity.ToTable("course_modules");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CourseId).HasColumnName("courseID");
            entity.Property(e => e.ModuleId).HasColumnName("moduleID");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseModules)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__course_mo__cours__656C112C");

            entity.HasOne(d => d.Module).WithMany(p => p.CourseModules)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__course_mo__modul__66603565");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__faculty__3214EC279B481A45");

            entity.ToTable("faculty");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.EmailId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("emailID");
            entity.Property(e => e.Namefirst)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("namefirst");
            entity.Property(e => e.Namelast)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("namelast");
        });

        modelBuilder.Entity<FacultyAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__faculty___3214EC27BD61FAC5");

            entity.ToTable("faculty_address");

            entity.HasIndex(e => e.FacultyId, "UQ__faculty___DBBF6FD0A977E853").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.FacultyId).HasColumnName("facultyID");

            entity.HasOne(d => d.Faculty).WithOne(p => p.FacultyAddress)
                .HasForeignKey<FacultyAddress>(d => d.FacultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__faculty_a__facul__60A75C0F");
        });

        modelBuilder.Entity<FacultyPhone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__faculty___3214EC271CA0A866");

            entity.ToTable("faculty_phone");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FacultyId).HasColumnName("facultyID");
            entity.Property(e => e.Number)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("number");

            entity.HasOne(d => d.Faculty).WithMany(p => p.FacultyPhones)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK__faculty_p__facul__5CD6CB2B");
        });

        modelBuilder.Entity<FacultyQualification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__faculty___3214EC2780CF8F69");

            entity.ToTable("faculty_qualifications");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.College)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("college");
            entity.Property(e => e.FacultyId).HasColumnName("facultyID");
            entity.Property(e => e.Marks)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("marks");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.University)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("university");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Faculty).WithMany(p => p.FacultyQualifications)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK__faculty_q__facul__6C190EBB");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__modules__3214EC276E3D659E");

            entity.ToTable("modules");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student__3214EC279FAB1447");

            entity.ToTable("student");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.EmailId)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("emailID");
            entity.Property(e => e.Namefirst)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("namefirst");
            entity.Property(e => e.Namelast)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("namelast");
        });

        modelBuilder.Entity<StudentAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student___3214EC27094CC4C1");

            entity.ToTable("student_address");

            entity.HasIndex(e => e.StudentId, "UQ__student___4D11D65DE2E27B51").IsUnique();

            entity.HasIndex(e => e.Address, "UQ__student___751C8E544A41B2B2").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.StudentId).HasColumnName("studentID");

            entity.HasOne(d => d.Student).WithOne(p => p.StudentAddress)
                .HasForeignKey<StudentAddress>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student_a__stude__5812160E");
        });

        modelBuilder.Entity<StudentCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student___3214EC275F1274E6");

            entity.ToTable("student_Cards");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StudentId).HasColumnName("studentID");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentCards)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__student_C__stude__534D60F1");
        });

        modelBuilder.Entity<StudentOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student___3214EC2753BB94FD");

            entity.ToTable("student_order");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Orderdate).HasColumnName("orderdate");
            entity.Property(e => e.StudentId).HasColumnName("studentID");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentOrders)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__student_o__stude__4D94879B");
        });

        modelBuilder.Entity<StudentPhone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student___3214EC27C13F56DB");

            entity.ToTable("student_phone");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Number)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.StudentId).HasColumnName("studentID");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentPhones)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__student_p__stude__5070F446");
        });

        modelBuilder.Entity<StudentQualification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student___3214EC27C8255211");

            entity.ToTable("student_qualifications");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.College)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("college");
            entity.Property(e => e.Marks)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("marks");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StudentId).HasColumnName("studentID");
            entity.Property(e => e.University)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("university");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentQualifications)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__student_q__stude__693CA210");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
