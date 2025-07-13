using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestTaskForBioGenom.Database.Entities;

namespace TestTaskForBioGenom.Database;

public partial class BioGenomDbContext : DbContext
{
    public BioGenomDbContext()
    {
    }

    public BioGenomDbContext(DbContextOptions<BioGenomDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DietarySupplement> DietarySupplements { get; set; }

    public virtual DbSet<DietarySupplementsVitamine> DietarySupplementsVitamines { get; set; }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vitamine> Vitamines { get; set; }

    public virtual DbSet<VitaminesForm> VitaminesForms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BioGenomDb;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DietarySupplement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dietary_supplements_pkey");

            entity.ToTable("dietary_supplements");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DailyIntake).HasColumnName("daily_intake");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.TabletsCount).HasColumnName("tablets_count");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<DietarySupplementsVitamine>(entity =>
        {
            entity.HasKey(e => new { e.DietarySupplementId, e.VitamineId }).HasName("dietary_supplements_vitamines_pkey");

            entity.ToTable("dietary_supplements_vitamines");

            entity.Property(e => e.DietarySupplementId).HasColumnName("dietary_supplement_id");
            entity.Property(e => e.VitamineId).HasColumnName("vitamine_id");
            entity.Property(e => e.VolumePerTablet).HasColumnName("volume_per_tablet");

            entity.HasOne(d => d.DietarySupplement).WithMany(p => p.DietarySupplementsVitamines)
                .HasForeignKey(d => d.DietarySupplementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dietary_supplements_vitamines_dietary_supplement_id_fkey");

            entity.HasOne(d => d.Vitamine).WithMany(p => p.DietarySupplementsVitamines)
                .HasForeignKey(d => d.VitamineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dietary_supplements_vitamines_vitamine_id_fkey");
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("forms_pkey");

            entity.ToTable("forms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Forms)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("forms_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Vitamine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("vitamines_pkey");

            entity.ToTable("vitamines");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DailyIntake).HasColumnName("daily_intake");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
            entity.Property(e => e.Unit)
                .HasMaxLength(30)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<VitaminesForm>(entity =>
        {
            entity.HasKey(e => new { e.VitamineId, e.FormId }).HasName("vitamines_forms_pkey");

            entity.ToTable("vitamines_forms");

            entity.Property(e => e.VitamineId).HasColumnName("vitamine_id");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.Intake).HasColumnName("intake");

            entity.HasOne(d => d.Form).WithMany(p => p.VitaminesForms)
                .HasForeignKey(d => d.FormId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vitamines_forms_form_id_fkey");

            entity.HasOne(d => d.Vitamine).WithMany(p => p.VitaminesForms)
                .HasForeignKey(d => d.VitamineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vitamines_forms_vitamine_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
