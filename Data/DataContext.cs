using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WorldCupAPI.Models;

namespace WorldCupAPI.Data;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Confederation> Confederations { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Confederation>(entity =>
        {
            entity.HasKey(e => e.ConfederationId).HasName("confederationId");

            entity.ToTable("Confederation");

            entity.Property(e => e.ConfederationId).HasColumnName("confederationId");
            entity.Property(e => e.ConfederationName)
                .HasMaxLength(50)
                .HasColumnName("confederationName");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("Team");

            entity.Property(e => e.TeamId).HasColumnName("teamId");
            entity.Property(e => e.ConfederationId).HasColumnName("confederationId");
            entity.Property(e => e.CountryName)
                .HasMaxLength(50)
                .HasColumnName("countryName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
