using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Avto1;

public partial class AvtoshkolaContext : DbContext
{
    public AvtoshkolaContext()
    {
    }

    public AvtoshkolaContext(DbContextOptions<AvtoshkolaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Avtopark> Avtoparks { get; set; }

    public virtual DbSet<Avtorizaciya> Avtorizaciyas { get; set; }

    public virtual DbSet<Dogovori> Dogovoris { get; set; }

    public virtual DbSet<Gruppi> Gruppis { get; set; }

    public virtual DbSet<Polzovateli> Polzovatelis { get; set; }

    public virtual DbSet<Roli> Rolis { get; set; }

    public virtual DbSet<Tipmashin> Tipmashins { get; set; }

    public virtual DbSet<Tipzanyatiya> Tipzanyatiyas { get; set; }

    public virtual DbSet<Zanyatiya> Zanyatiyas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Username=postgres;Password=Ujhbkrf54;Database=Avtoshkola");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avtopark>(entity =>
        {
            entity.HasKey(e => e.Idmashini).HasName("avtopark_pkey");

            entity.ToTable("avtopark");

            entity.Property(e => e.Idmashini)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idmashini");
            entity.Property(e => e.Idtipmashin).HasColumnName("idtipmashin");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");

            entity.HasOne(d => d.IdtipmashinNavigation).WithMany(p => p.Avtoparks)
                .HasForeignKey(d => d.Idtipmashin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("avtopark_idtipmashin_fkey");
        });

        modelBuilder.Entity<Avtorizaciya>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("avtorizaciya_pkey");

            entity.ToTable("avtorizaciya");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Idpolzovateli).HasColumnName("idpolzovateli");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");
            entity.Property(e => e.Parol)
                .HasMaxLength(20)
                .HasColumnName("parol");

            entity.HasOne(d => d.IdpolzovateliNavigation).WithMany(p => p.Avtorizaciyas)
                .HasForeignKey(d => d.Idpolzovateli)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("avtorizaciya_idpolzovateli_fkey");
        });

        modelBuilder.Entity<Dogovori>(entity =>
        {
            entity.HasKey(e => e.Iddogovora).HasName("dogovori_pkey");

            entity.ToTable("dogovori");

            entity.Property(e => e.Iddogovora)
                .UseIdentityAlwaysColumn()
                .HasColumnName("iddogovora");
            entity.Property(e => e.Dataokonchaniya).HasColumnName("dataokonchaniya");
            entity.Property(e => e.Datazaklucheniya).HasColumnName("datazaklucheniya");
            entity.Property(e => e.Idpolzovateli).HasColumnName("idpolzovateli");
            entity.Property(e => e.Vnesennayasumma)
                .HasColumnType("money")
                .HasColumnName("vnesennayasumma");

            entity.HasOne(d => d.IdpolzovateliNavigation).WithMany(p => p.Dogovoris)
                .HasForeignKey(d => d.Idpolzovateli)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dogovori_idpolzovateli_fkey");
        });

        modelBuilder.Entity<Gruppi>(entity =>
        {
            entity.HasKey(e => e.Idgruppi).HasName("gruppi_pkey");

            entity.ToTable("gruppi");

            entity.Property(e => e.Idgruppi)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idgruppi");
            entity.Property(e => e.Dataformirovaniya).HasColumnName("dataformirovaniya");
        });

        modelBuilder.Entity<Polzovateli>(entity =>
        {
            entity.HasKey(e => e.Idpolzovateli).HasName("polzovateli_pkey");

            entity.ToTable("polzovateli");

            entity.Property(e => e.Idpolzovateli)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idpolzovateli");
            entity.Property(e => e.Familiya)
                .HasMaxLength(30)
                .HasColumnName("familiya");
            entity.Property(e => e.Idgruppi).HasColumnName("idgruppi");
            entity.Property(e => e.Idroli).HasColumnName("idroli");
            entity.Property(e => e.Imya)
                .HasMaxLength(20)
                .HasColumnName("imya");
            entity.Property(e => e.Otchestvo)
                .HasMaxLength(30)
                .HasColumnName("otchestvo");

            entity.HasOne(d => d.IdgruppiNavigation).WithMany(p => p.Polzovatelis)
                .HasForeignKey(d => d.Idgruppi)
                .HasConstraintName("polzovateli_idgruppi_fkey");

            entity.HasOne(d => d.IdroliNavigation).WithMany(p => p.Polzovatelis)
                .HasForeignKey(d => d.Idroli)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("polzovateli_idroli_fkey");
        });

        modelBuilder.Entity<Roli>(entity =>
        {
            entity.HasKey(e => e.Idroli).HasName("roli_pkey");

            entity.ToTable("roli");

            entity.Property(e => e.Idroli)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idroli");
            entity.Property(e => e.Nazvanieroli)
                .HasMaxLength(30)
                .HasColumnName("nazvanieroli");
        });

        modelBuilder.Entity<Tipmashin>(entity =>
        {
            entity.HasKey(e => e.Idtipmashin).HasName("tipmashin_pkey");

            entity.ToTable("tipmashin");

            entity.Property(e => e.Idtipmashin)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idtipmashin");
            entity.Property(e => e.Nazvanie)
                .HasMaxLength(30)
                .HasColumnName("nazvanie");
        });

        modelBuilder.Entity<Tipzanyatiya>(entity =>
        {
            entity.HasKey(e => e.Idtipzanyatiya).HasName("tipzanyatiya_pkey");

            entity.ToTable("tipzanyatiya");

            entity.Property(e => e.Idtipzanyatiya)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idtipzanyatiya");
            entity.Property(e => e.Nazvanie)
                .HasMaxLength(30)
                .HasColumnName("nazvanie");
            entity.Property(e => e.Prodolgitelnost).HasColumnName("prodolgitelnost");
        });

        modelBuilder.Entity<Zanyatiya>(entity =>
        {
            entity.HasKey(e => e.Idzanyatiya).HasName("zanyatiya_pkey");

            entity.ToTable("zanyatiya");

            entity.Property(e => e.Idzanyatiya)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idzanyatiya");
            entity.Property(e => e.Ayditoriya)
                .HasMaxLength(10)
                .HasColumnName("ayditoriya");
            entity.Property(e => e.Datazanyatiya).HasColumnName("datazanyatiya");
            entity.Property(e => e.Idgruppi).HasColumnName("idgruppi");
            entity.Property(e => e.Idmashini).HasColumnName("idmashini");
            entity.Property(e => e.Idtipzanyatiya).HasColumnName("idtipzanyatiya");
            entity.Property(e => e.Instruktor).HasColumnName("instruktor");
            entity.Property(e => e.Vremya)
                .HasColumnType("time with time zone")
                .HasColumnName("vremya");
            entity.Property(e => e.Ychenik).HasColumnName("ychenik");

            entity.HasOne(d => d.IdgruppiNavigation).WithMany(p => p.Zanyatiyas)
                .HasForeignKey(d => d.Idgruppi)
                .HasConstraintName("zanyatiya_idgruppi_fkey");

            entity.HasOne(d => d.IdmashiniNavigation).WithMany(p => p.Zanyatiyas)
                .HasForeignKey(d => d.Idmashini)
                .HasConstraintName("zanyatiya_idmashini_fkey");

            entity.HasOne(d => d.IdtipzanyatiyaNavigation).WithMany(p => p.Zanyatiyas)
                .HasForeignKey(d => d.Idtipzanyatiya)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zanyatiya_idtipzanyatiya_fkey");

            entity.HasOne(d => d.InstruktorNavigation).WithMany(p => p.ZanyatiyaInstruktorNavigations)
                .HasForeignKey(d => d.Instruktor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zanyatiya_instruktor_fkey");

            entity.HasOne(d => d.YchenikNavigation).WithMany(p => p.ZanyatiyaYchenikNavigations)
                .HasForeignKey(d => d.Ychenik)
                .HasConstraintName("zanyatiya_ychenik_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
