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


    //ignore or use temp ta
    //public virtual DbSet<Typing2024_NoId> Typing2024_NoIds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=TypingProgress; Trusted_Connection=True; MultipleActiveResultSets=true");

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
