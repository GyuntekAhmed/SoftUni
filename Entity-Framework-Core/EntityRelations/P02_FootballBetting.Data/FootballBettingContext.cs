﻿namespace P02_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;

    using Common;
    using Models;

    public class FootballBettingContext : DbContext
    {
        // Use it when developing the application
        // When we test the application locally on out PC

        public FootballBettingContext()
        {
            
        }

        // Loading of the DbContext with DI

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; } = null!;

        public DbSet<Color> Colors { get; set; } = null!;

        public DbSet<Town> Towns { get; set; } = null!;

        public DbSet<Country> Countries { get; set; } = null!;

        public DbSet<Player> Players { get; set; } = null!;

        public DbSet<Position> Positions { get; set; } = null!;

        public DbSet<PlayerStatistic> PlayersStatistics { get; set; } = null!;

        public DbSet<Game> Games { get; set; } = null!;

        public DbSet<Bet> Bets { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;

        // Connection configuration

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Set default connection string
                optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        // Fluent API and Entities config

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new { ps.GameId, ps.PlayerId });
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitKolorId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity
                    .HasOne(g => g.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity
                    .HasOne(g => g.AweayTeam)
                    .WithMany(t => t.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
