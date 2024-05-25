using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RoadsOfRussiaWeb.Entities;

public partial class DbRoadContext : DbContext
{
    public DbRoadContext()
    {
    }

    public DbRoadContext(DbContextOptions<DbRoadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<DocumentSection> DocumentSections { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<InformationProject> InformationProjects { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    public virtual DbSet<MaterialCard> MaterialCards { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StructuralDivision> StructuralDivisions { get; set; }

    public virtual DbSet<TemporaryAbsenceEmployee> TemporaryAbsenceEmployees { get; set; }

    public virtual DbSet<TypeEvent> TypeEvents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=dbRoad;TrustServerCertificate=true;Trusted_Connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.ToTable("Candidate");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<DocumentSection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TypeLibrary");

            entity.ToTable("DocumentSection");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AsssistantDirector).HasMaxLength(150);
            entity.Property(e => e.Cabinet).HasMaxLength(50);
            entity.Property(e => e.Director).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Idrole).HasColumnName("IDRole");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.OtherInformation).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
            entity.Property(e => e.WorkPhone).HasMaxLength(50);

            entity.HasOne(d => d.IdJobTitleNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdJobTitle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_JobTitle");

            entity.HasOne(d => d.IdStructuralDivisionNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdStructuralDivision)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_StructuralDivision");

            entity.HasOne(d => d.IdroleNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Idrole)
                .HasConstraintName("FK_Employee_Role");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.ToTable("Event");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateTimeEvent).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.NameEvent).HasMaxLength(50);

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK_Event_Employee");

            entity.HasOne(d => d.IdStatusEventNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdStatusEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Event_StatusEvent");

            entity.HasOne(d => d.IdTypeEventNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdTypeEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Event_TypeEvent");
        });

        modelBuilder.Entity<InformationProject>(entity =>
        {
            entity.ToTable("InformationProject");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NameProject).HasMaxLength(50);

            entity.HasOne(d => d.IdDirectorProjectNavigation).WithMany(p => p.InformationProjects)
                .HasForeignKey(d => d.IdDirectorProject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InformationProject_Employee");
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.ToTable("JobTitle");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.IdStructuralDivisionNavigation).WithMany(p => p.JobTitles)
                .HasForeignKey(d => d.IdStructuralDivision)
                .HasConstraintName("FK_JobTitle_StructuralDivision");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.ToTable("Library");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PathToDocument).HasMaxLength(50);

            entity.HasOne(d => d.IdDocumentSectionNavigation).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.IdDocumentSection)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Library_TypeLibrary");
        });

        modelBuilder.Entity<MaterialCard>(entity =>
        {
            entity.ToTable("MaterialCard");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Area).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.MaterialCards)
                .HasForeignKey(d => d.IdAuthor)
                .HasConstraintName("FK_MaterialCard_Employee");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.MaterialCards)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("FK_MaterialCard_Status");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.News)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_News_Employee");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StatusEvent");

            entity.ToTable("Status");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<StructuralDivision>(entity =>
        {
            entity.ToTable("StructuralDivision");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<TemporaryAbsenceEmployee>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.TemporaryAbsenceEmployees)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TemporaryAbsenceEmployees_Employee");
        });

        modelBuilder.Entity<TypeEvent>(entity =>
        {
            entity.ToTable("TypeEvent");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
