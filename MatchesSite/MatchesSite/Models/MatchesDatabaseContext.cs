using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MatchesSite.Models
{
    public partial class MatchesDatabaseContext : DbContext
    {
        public MatchesDatabaseContext()
        {
        }

        public MatchesDatabaseContext(DbContextOptions<MatchesDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookies> Bookies { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Leagues> Leagues { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<Opportunities> Opportunities { get; set; }
        public virtual DbSet<Profits> Profits { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MatchesDatabase;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookies>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Leagues>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Leagues)
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Leagues_Countries");
            });

            modelBuilder.Entity<Matches>(entity =>
            {
                entity.HasIndex(e => e.Hash)
                    .HasName("UQ_Matches")
                    .IsUnique();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e._1).HasColumnName("1");

                entity.Property(e => e._2).HasColumnName("2");

                entity.HasOne(d => d.AwayNavigation)
                    .WithMany(p => p.MatchesAwayNavigation)
                    .HasForeignKey(d => d.Away)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matches_Away");

                entity.HasOne(d => d.BookieNavigation)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.Bookie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matches_Bookies");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK_Matches_Countries");

                entity.HasOne(d => d.HomeNavigation)
                    .WithMany(p => p.MatchesHomeNavigation)
                    .HasForeignKey(d => d.Home)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matches_Home");

                entity.HasOne(d => d.LeagueNavigation)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.League)
                    .HasConstraintName("FK_Matches_Leagues");

                entity.HasOne(d => d.Opportunity)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.OpportunityId)
                    .HasConstraintName("FK_Matches_Opportunities");
            });

            modelBuilder.Entity<Opportunities>(entity =>
            {
                entity.HasIndex(e => e.Hash)
                    .HasName("UQ_Opportunities")
                    .IsUnique();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e._1).HasColumnName("1");

                entity.Property(e => e._2).HasColumnName("2");

                entity.HasOne(d => d.AwayNavigation)
                    .WithMany(p => p.OpportunitiesAwayNavigation)
                    .HasForeignKey(d => d.Away)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Away");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Opportunities)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK_Opportunities_Countries");

                entity.HasOne(d => d.HomeNavigation)
                    .WithMany(p => p.OpportunitiesHomeNavigation)
                    .HasForeignKey(d => d.Home)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Home");

                entity.HasOne(d => d.Id1Navigation)
                    .WithMany(p => p.OpportunitiesId1Navigation)
                    .HasForeignKey(d => d.Id1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_1");

                entity.HasOne(d => d.Id2Navigation)
                    .WithMany(p => p.OpportunitiesId2Navigation)
                    .HasForeignKey(d => d.Id2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_2");

                entity.HasOne(d => d.IdXNavigation)
                    .WithMany(p => p.OpportunitiesIdXNavigation)
                    .HasForeignKey(d => d.IdX)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_X");

                entity.HasOne(d => d.LeagueNavigation)
                    .WithMany(p => p.Opportunities)
                    .HasForeignKey(d => d.League)
                    .HasConstraintName("FK_Opportunities_Leagues");
            });

            modelBuilder.Entity<Profits>(entity =>
            {
                entity.Property(e => e.Roi).HasColumnName("ROI");

                entity.HasOne(d => d.Opportunity)
                    .WithMany(p => p.Profits)
                    .HasForeignKey(d => d.OpportunityId)
                    .HasConstraintName("FK_Profits_Opportunities");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK_Teams_Countries");

                entity.HasOne(d => d.LeagueNavigation)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.League)
                    .HasConstraintName("FK_Teams_Leagues");
            });
        }
    }
}
