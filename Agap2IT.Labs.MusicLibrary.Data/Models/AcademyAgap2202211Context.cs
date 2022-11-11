using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Agap2IT.Labs.MusicLibrary.Data.Models;

public partial class AcademyAgap2202211Context : DbContext
{
    public AcademyAgap2202211Context()
    {
    }

    public AcademyAgap2202211Context(DbContextOptions<AcademyAgap2202211Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Band> Bands { get; set; }

    public virtual DbSet<BandMember> BandMembers { get; set; }

    public virtual DbSet<SoundTrack> SoundTracks { get; set; }

    public virtual DbSet<SoundTrackBand> SoundTrackBands { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<SubscriptionLog> SubscriptionLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:academies-moongy.database.windows.net,1433;Database=MusicLibraryDB;User Id=appadmin; Password=qwert#4477;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.Property(e => e.LogoImage)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.ReleaseDate).HasColumnType("date");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.Property(e => e.DateBirth).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Band>(entity =>
        {
            entity.Property(e => e.Image)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<BandMember>(entity =>
        {
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.JoinDate).HasColumnType("date");

            entity.HasOne(d => d.Artist).WithMany(p => p.BandMembers)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BandMembers_Artists");

            entity.HasOne(d => d.Band).WithMany(p => p.BandMembers)
                .HasForeignKey(d => d.BandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BandMembers_Bands");
        });

        modelBuilder.Entity<SoundTrack>(entity =>
        {
            entity.Property(e => e.Image)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.SoundBinary)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.Album).WithMany(p => p.SoundTracks)
                .HasForeignKey(d => d.AlbumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SoundTracks_Albums");
        });

        modelBuilder.Entity<SoundTrackBand>(entity =>
        {
            entity.Property(e => e.IsLead).HasColumnName("isLead");

            entity.HasOne(d => d.Band).WithMany(p => p.SoundTrackBands)
                .HasForeignKey(d => d.BandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SoundTrackBands_Bands");

            entity.HasOne(d => d.SoundTrack).WithMany(p => p.SoundTrackBands)
                .HasForeignKey(d => d.SoundTrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SoundTrackBands_SoundTracks");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<SubscriptionLog>(entity =>
        {
            entity.HasOne(d => d.Subscription).WithMany(p => p.SubscriptionLogs)
                .HasForeignKey(d => d.SubscriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubscriptionLogs_Subscriptions");

            entity.HasOne(d => d.User).WithMany(p => p.SubscriptionLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubscriptionLogs_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Uuid, "UUID_Users_Unique").IsUnique();

            entity.Property(e => e.DateBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
