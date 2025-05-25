using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPITestProj1.Models;

public partial class TypingDBContext : DbContext
{
    public TypingDBContext()
    {
    }

    public TypingDBContext(DbContextOptions<TypingDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Typing2024> Typing2024s { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Typing2024>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Typing20__3214EC27002E0CEF");

            entity.ToTable("Typing2024");

            entity.Property(e => e.Accuracy).HasMaxLength(10);
            entity.Property(e => e.Date).HasMaxLength(10);
            entity.Property(e => e.Percentage_Complete).HasMaxLength(10);
            entity.Property(e => e.Type).HasMaxLength(12);
            entity.Property(e => e.WPM).HasColumnType("decimal(3, 0)");
        });

        //{
        //    entity
        //        .HasNoKey()
        //        .ToTable("Typing2024_NoId");

        //    entity.Property(e => e.Accuracy).HasMaxLength(10);
        //    entity.Property(e => e.Date).HasMaxLength(10);
        //    entity.Property(e => e.Percentage_Complete).HasMaxLength(10);
        //    entity.Property(e => e.Type).HasMaxLength(12);
        //    entity.Property(e => e.WPM).HasColumnType("decimal(3, 0)");
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
