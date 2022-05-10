using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiplomApi
{
    public partial class diplom1Context : DbContext
    {
        public diplom1Context()
        {
        }

        public diplom1Context(DbContextOptions<diplom1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Applicant> Applicants { get; set; } = null!;
        public virtual DbSet<MediaFile> MediaFiles { get; set; } = null!;
        public virtual DbSet<QuestQuestion> QuestQuestions { get; set; } = null!;
        public virtual DbSet<QuestRating> QuestRatings { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("workstation id=diplom1.mssql.somee.com;packet size=4096;user id=slothfuldaria_SQLLogin_1;pwd=7swrt2cb39;data source=diplom1.mssql.somee.com;persist security info=False;initial catalog=diplom1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.Property(e => e.IdAdmin).ValueGeneratedOnAdd();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsFixedLength();

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.IdAdmin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admins_Users1");
            });

            modelBuilder.Entity<Applicant>(entity =>
            {
                entity.HasKey(e => e.IdApplicants);

                entity.Property(e => e.IdApplicants).ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsFixedLength();

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.HasOne(d => d.IdApplicantsNavigation)
                    .WithOne(p => p.Applicant)
                    .HasForeignKey<Applicant>(d => d.IdApplicants)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applicants_Users1");
            });

            modelBuilder.Entity<MediaFile>(entity =>
            {
                entity.ToTable("mediaFiles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Midiatype)
                    .HasMaxLength(50)
                    .HasColumnName("midiatype");

                entity.Property(e => e.Path).HasColumnName("path");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<QuestQuestion>(entity =>
            {
                entity.HasKey(e => e.IdQuest);

                entity.Property(e => e.IdQuest).ValueGeneratedNever();
            });

            modelBuilder.Entity<QuestRating>(entity =>
            {
                entity.ToTable("QuestRating");

                entity.Property(e => e.Answers).HasColumnName("answers");

                entity.Property(e => e.Date)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Result).HasMaxLength(50);

                entity.HasOne(d => d.IdApplicantNavigation)
                    .WithMany(p => p.QuestRatings)
                    .HasForeignKey(d => d.IdApplicant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestRating_Applicants");

                entity.HasOne(d => d.IdQuestNavigation)
                    .WithMany(p => p.QuestRatings)
                    .HasForeignKey(d => d.IdQuest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestRating_QuestQuestions");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Login, "IX_Users")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
