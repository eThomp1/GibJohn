using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace GibJohn.Models;

public partial class TlS2303064GibJohnContext : DbContext
{
    public TlS2303064GibJohnContext()
    {
    }

    public TlS2303064GibJohnContext(DbContextOptions<TlS2303064GibJohnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<User> Users { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PRIMARY");

            entity.ToTable("game");

            entity.HasIndex(e => e.GameId, "GameID_UNIQUE").IsUnique();

            entity.HasIndex(e => e.UserId, "UserID_idx");

            entity.Property(e => e.GameId).HasColumnName("GameID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Games)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("UserID");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PRIMARY");

            entity.ToTable("questions");

            entity.HasIndex(e => e.GameId, "GameID_idx");

            entity.HasIndex(e => e.QuestionId, "QuestionID_UNIQUE").IsUnique();

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.GameId).HasColumnName("GameID");
            entity.Property(e => e.QuestionCorrect).HasMaxLength(45);
            entity.Property(e => e.QuestionText).HasMaxLength(45);
            entity.Property(e => e.QuestionWrong1).HasMaxLength(45);
            entity.Property(e => e.QuestionWrong2).HasMaxLength(45);
            entity.Property(e => e.QuestionWrong3).HasMaxLength(45);

            entity.HasOne(d => d.Game).WithMany(p => p.Questions)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("GameID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "Email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.UserId, "UserID_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Username, "Username_UNIQUE").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.FirstName).HasMaxLength(45);
            entity.Property(e => e.LastName).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);
            entity.Property(e => e.Username).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
