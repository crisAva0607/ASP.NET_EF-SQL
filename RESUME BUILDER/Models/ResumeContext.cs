using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RESUME_BUILDER.Models;

public partial class ResumeContext : DbContext
{
    public ResumeContext()
    {
    }

    public ResumeContext(DbContextOptions<ResumeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CharacterReference> CharacterReferences { get; set; }

    public virtual DbSet<EducationBg> EducationBgs { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Link> Links { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Training> Trainings { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=REBIRTH\\SQLEXPRESS;Database=RESUME;ConnectRetryCount=0;user=sa;password=tupe123;Persist Security Info=true;trustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CharacterReference>(entity =>
        {
            entity.ToTable("CharacterReference");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Company)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Job)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Student).WithMany(p => p.CharacterReferences)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_CharacterReference_Student");
        });

        modelBuilder.Entity<EducationBg>(entity =>
        {
            entity.ToTable("EducationBG");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Course)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.School)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.YearAttended)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.EducationBgs)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_EducationBG_Student");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.ToTable("Experience");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Company)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Student).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Experience_Student");
        });

        modelBuilder.Entity<Link>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Github)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Student).WithMany(p => p.Links)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Links_Student");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.ToTable("Skill");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SkillName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Student).WithMany(p => p.Skills)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Skill_Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Objective).IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.TrainingName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.YearAttended)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Training)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Trainings_Student");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
