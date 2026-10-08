using System;
using System.Collections.Generic;
using FE53728API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FE53728API.Data;

public partial class CourseManegmentContext : DbContext
{
    public CourseManegmentContext()
    {
    }

    public CourseManegmentContext(DbContextOptions<CourseManegmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Batch> Batches { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=CourseManagementDbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Batch>(entity =>
        {
            entity.ToTable("Batch");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.EnrollmentStatus).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(150);

            entity.HasOne(d => d.Course).WithMany(p => p.Batches)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Batch_Course");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Course1");

            entity.ToTable("Course");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User");

            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("Full Name");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
