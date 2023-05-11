using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GatoAPI.Models;

public partial class Sistem21GatoContext : DbContext
{
    public Sistem21GatoContext()
    {
    }

    public Sistem21GatoContext(DbContextOptions<Sistem21GatoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Jugador> Jugador { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Jugador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("jugador");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.PartidasGanadas).HasColumnType("int(11)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
