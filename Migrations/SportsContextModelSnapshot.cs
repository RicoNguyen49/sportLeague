﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sportLeague.Models;

#nullable disable

namespace sportLeague.Migrations
{
    [DbContext(typeof(SportsContext))]
    partial class SportsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("sportLeague.Models.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeagueId"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SportType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("YearFounded")
                        .HasColumnType("int");

                    b.HasKey("LeagueId");

                    b.ToTable("Leagues");

                    b.HasData(
                        new
                        {
                            LeagueId = 1,
                            Country = "USA",
                            Name = "National Basketball Association",
                            SportType = "Basketball",
                            YearFounded = 1946
                        },
                        new
                        {
                            LeagueId = 2,
                            Country = "England",
                            Name = "Premier League",
                            SportType = "Football",
                            YearFounded = 1992
                        },
                        new
                        {
                            LeagueId = 3,
                            Country = "USA",
                            Name = "Major League Baseball",
                            SportType = "Baseball",
                            YearFounded = 1869
                        });
                });

            modelBuilder.Entity("sportLeague.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerId = 1,
                            Age = 39,
                            FirstName = "LeBron",
                            LastName = "James",
                            Position = "Forward",
                            TeamId = 1
                        },
                        new
                        {
                            PlayerId = 2,
                            Age = 30,
                            FirstName = "Anthony",
                            LastName = "Davis",
                            Position = "Forward-Center",
                            TeamId = 1
                        },
                        new
                        {
                            PlayerId = 3,
                            Age = 25,
                            FirstName = "Jayson",
                            LastName = "Tatum",
                            Position = "Forward",
                            TeamId = 2
                        },
                        new
                        {
                            PlayerId = 4,
                            Age = 27,
                            FirstName = "Jaylen",
                            LastName = "Brown",
                            Position = "Guard-Forward",
                            TeamId = 2
                        },
                        new
                        {
                            PlayerId = 5,
                            Age = 26,
                            FirstName = "Marcus",
                            LastName = "Rashford",
                            Position = "Forward",
                            TeamId = 3
                        },
                        new
                        {
                            PlayerId = 6,
                            Age = 29,
                            FirstName = "Bruno",
                            LastName = "Fernandes",
                            Position = "Midfielder",
                            TeamId = 3
                        },
                        new
                        {
                            PlayerId = 7,
                            Age = 29,
                            FirstName = "Raheem",
                            LastName = "Sterling",
                            Position = "Forward",
                            TeamId = 4
                        },
                        new
                        {
                            PlayerId = 8,
                            Age = 39,
                            FirstName = "Thiago",
                            LastName = "Silva",
                            Position = "Defender",
                            TeamId = 4
                        },
                        new
                        {
                            PlayerId = 9,
                            Age = 31,
                            FirstName = "Aaron",
                            LastName = "Judge",
                            Position = "Outfielder",
                            TeamId = 5
                        },
                        new
                        {
                            PlayerId = 10,
                            Age = 33,
                            FirstName = "Gerrit",
                            LastName = "Cole",
                            Position = "Pitcher",
                            TeamId = 5
                        },
                        new
                        {
                            PlayerId = 11,
                            Age = 31,
                            FirstName = "Mookie",
                            LastName = "Betts",
                            Position = "Outfielder",
                            TeamId = 6
                        },
                        new
                        {
                            PlayerId = 12,
                            Age = 36,
                            FirstName = "Clayton",
                            LastName = "Kershaw",
                            Position = "Pitcher",
                            TeamId = 6
                        });
                });

            modelBuilder.Entity("sportLeague.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("YearEstablished")
                        .HasColumnType("int");

                    b.HasKey("TeamId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            City = "Los Angeles",
                            LeagueId = 1,
                            Name = "Los Angeles Lakers",
                            YearEstablished = 1947
                        },
                        new
                        {
                            TeamId = 2,
                            City = "Boston",
                            LeagueId = 1,
                            Name = "Boston Celtics",
                            YearEstablished = 1946
                        },
                        new
                        {
                            TeamId = 3,
                            City = "Manchester",
                            LeagueId = 2,
                            Name = "Manchester United",
                            YearEstablished = 1878
                        },
                        new
                        {
                            TeamId = 4,
                            City = "London",
                            LeagueId = 2,
                            Name = "Chelsea",
                            YearEstablished = 1905
                        },
                        new
                        {
                            TeamId = 5,
                            City = "New York",
                            LeagueId = 3,
                            Name = "New York Yankees",
                            YearEstablished = 1901
                        },
                        new
                        {
                            TeamId = 6,
                            City = "Los Angeles",
                            LeagueId = 3,
                            Name = "Los Angeles Dodgers",
                            YearEstablished = 1883
                        });
                });

            modelBuilder.Entity("sportLeague.Models.Player", b =>
                {
                    b.HasOne("sportLeague.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("sportLeague.Models.Team", b =>
                {
                    b.HasOne("sportLeague.Models.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });

            modelBuilder.Entity("sportLeague.Models.League", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("sportLeague.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
