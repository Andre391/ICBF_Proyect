using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ICBF_Project.Models;

public partial class DbIcbfContext : DbContext
{
    public DbIcbfContext()
    {
    }

    public DbIcbfContext(DbContextOptions<DbIcbfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencia> Asistencias { get; set; }

    public virtual DbSet<AvanceAcademico> AvanceAcademicos { get; set; }

    public virtual DbSet<Jardine> Jardines { get; set; }

    public virtual DbSet<Nino> Ninos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.PkIdAsistencia);

            entity.Property(e => e.PkIdAsistencia).HasColumnName("PkId_Asistencia");
            entity.Property(e => e.EstadoNino)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Estado_Nino");
            entity.Property(e => e.FkNuip).HasColumnName("Fk_NUIP");

            entity.HasOne(d => d.oNino).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.FkNuip)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asistencias_Ninos");
        });

        modelBuilder.Entity<AvanceAcademico>(entity =>
        {
            entity.HasKey(e => e.PkIdAvanceAcademico);

            entity.ToTable("AvanceAcademico");

            entity.Property(e => e.PkIdAvanceAcademico).HasColumnName("PkId_AvanceAcademico");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaEntrega).HasColumnName("Fecha_Entrega");
            entity.Property(e => e.FkNuip).HasColumnName("Fk_NUIP");
            entity.Property(e => e.Nivel)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Notas)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.oNino).WithMany(p => p.AvanceAcademicos)
                .HasForeignKey(d => d.FkNuip)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AvanceAcademico_Ninos");
        });

        modelBuilder.Entity<Jardine>(entity =>
        {
            entity.HasKey(e => e.PkIdJardin);

            entity.Property(e => e.PkIdJardin).HasColumnName("PkId_Jardin");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Nino>(entity =>
        {
            entity.HasKey(e => e.PkNuip);

            entity.Property(e => e.PkNuip)
                .ValueGeneratedNever()
                .HasColumnName("Pk_NUIP");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Departamento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Eps)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EPS");
            entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.FkIdJardin).HasColumnName("FkId_Jardin");
            entity.Property(e => e.FkIdUsuario).HasColumnName("FkId_Usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoSangre)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Tipo_Sangre");

            entity.HasOne(d => d.oJardin).WithMany(p => p.Ninos)
                .HasForeignKey(d => d.FkIdJardin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ninos_Jardines");

            entity.HasOne(d => d.oUsuario).WithMany(p => p.Ninos)
                .HasForeignKey(d => d.FkIdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ninos_Usuarios");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.PkIdRol);

            entity.Property(e => e.PkIdRol).HasColumnName("PkId_Rol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.PkIdUsuario);

            entity.Property(e => e.PkIdUsuario).HasColumnName("PkId_Usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.FkIdRol).HasColumnName("FkId_Rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Usuario");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.oRol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.FkIdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
