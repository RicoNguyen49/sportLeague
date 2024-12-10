using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace sportLeague.Models
{
    public class SportsContext : DbContext
    {
        public DbSet<League> Leagues { get; set; } = null;
        public DbSet<Team> Teams { get; set; } = null;
        public DbSet<Player> Players { get; set; } = null;

        public SportsContext(DbContextOptions<SportsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for League
            modelBuilder.Entity<League>().HasData(
                new League { LeagueId = 1, Name = "National Basketball Association", Country = "USA", SportType = "Basketball", YearFounded = 1946 },
                new League { LeagueId = 2, Name = "Premier League", Country = "England", SportType = "Football", YearFounded = 1992 },
                new League { LeagueId = 3, Name = "Major League Baseball", Country = "USA", SportType = "Baseball", YearFounded = 1869 }
            );

            // Seed data for Team
            modelBuilder.Entity<Team>().HasData(
                new Team { TeamId = 1, Name = "Los Angeles Lakers", City = "Los Angeles", YearEstablished = 1947, LeagueId = 1 },
                new Team { TeamId = 2, Name = "Boston Celtics", City = "Boston", YearEstablished = 1946, LeagueId = 1 },
                new Team { TeamId = 3, Name = "Manchester United", City = "Manchester", YearEstablished = 1878, LeagueId = 2 },
                new Team { TeamId = 4, Name = "Chelsea", City = "London", YearEstablished = 1905, LeagueId = 2 },
                new Team { TeamId = 5, Name = "New York Yankees", City = "New York", YearEstablished = 1901, LeagueId = 3 },
                new Team { TeamId = 6, Name = "Los Angeles Dodgers", City = "Los Angeles", YearEstablished = 1883, LeagueId = 3 }
            );

            // Seed data for Player
            modelBuilder.Entity<Player>().HasData(
                new Player { PlayerId = 1, FirstName = "LeBron", LastName = "James", Position = "Forward", Age = 39, TeamId = 1 },
                new Player { PlayerId = 2, FirstName = "Anthony", LastName = "Davis", Position = "Forward-Center", Age = 30, TeamId = 1 },
                new Player { PlayerId = 3, FirstName = "Jayson", LastName = "Tatum", Position = "Forward", Age = 25, TeamId = 2 },
                new Player { PlayerId = 4, FirstName = "Jaylen", LastName = "Brown", Position = "Guard-Forward", Age = 27, TeamId = 2 },
                new Player { PlayerId = 5, FirstName = "Marcus", LastName = "Rashford", Position = "Forward", Age = 26, TeamId = 3 },
                new Player { PlayerId = 6, FirstName = "Bruno", LastName = "Fernandes", Position = "Midfielder", Age = 29, TeamId = 3 },
                new Player { PlayerId = 7, FirstName = "Raheem", LastName = "Sterling", Position = "Forward", Age = 29, TeamId = 4 },
                new Player { PlayerId = 8, FirstName = "Thiago", LastName = "Silva", Position = "Defender", Age = 39, TeamId = 4 },
                new Player { PlayerId = 9, FirstName = "Aaron", LastName = "Judge", Position = "Outfielder", Age = 31, TeamId = 5 },
                new Player { PlayerId = 10, FirstName = "Gerrit", LastName = "Cole", Position = "Pitcher", Age = 33, TeamId = 5 },
                new Player { PlayerId = 11, FirstName = "Mookie", LastName = "Betts", Position = "Outfielder", Age = 31, TeamId = 6 },
                new Player { PlayerId = 12, FirstName = "Clayton", LastName = "Kershaw", Position = "Pitcher", Age = 36, TeamId = 6 }
            );
        }
    }

}
