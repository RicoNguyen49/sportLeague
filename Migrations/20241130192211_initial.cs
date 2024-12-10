using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sportLeague.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SportType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    YearFounded = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearEstablished = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "LeagueId", "Country", "Name", "SportType", "YearFounded" },
                values: new object[,]
                {
                    { 1, "USA", "National Basketball Association", "Basketball", 1946 },
                    { 2, "England", "Premier League", "Football", 1992 },
                    { 3, "USA", "Major League Baseball", "Baseball", 1869 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "City", "LeagueId", "Name", "YearEstablished" },
                values: new object[,]
                {
                    { 1, "Los Angeles", 1, "Los Angeles Lakers", 1947 },
                    { 2, "Boston", 1, "Boston Celtics", 1946 },
                    { 3, "Manchester", 2, "Manchester United", 1878 },
                    { 4, "London", 2, "Chelsea", 1905 },
                    { 5, "New York", 3, "New York Yankees", 1901 },
                    { 6, "Los Angeles", 3, "Los Angeles Dodgers", 1883 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Age", "FirstName", "LastName", "Position", "TeamId" },
                values: new object[,]
                {
                    { 1, 39, "LeBron", "James", "Forward", 1 },
                    { 2, 30, "Anthony", "Davis", "Forward-Center", 1 },
                    { 3, 25, "Jayson", "Tatum", "Forward", 2 },
                    { 4, 27, "Jaylen", "Brown", "Guard-Forward", 2 },
                    { 5, 26, "Marcus", "Rashford", "Forward", 3 },
                    { 6, 29, "Bruno", "Fernandes", "Midfielder", 3 },
                    { 7, 29, "Raheem", "Sterling", "Forward", 4 },
                    { 8, 39, "Thiago", "Silva", "Defender", 4 },
                    { 9, 31, "Aaron", "Judge", "Outfielder", 5 },
                    { 10, 33, "Gerrit", "Cole", "Pitcher", 5 },
                    { 11, 31, "Mookie", "Betts", "Outfielder", 6 },
                    { 12, 36, "Clayton", "Kershaw", "Pitcher", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Leagues");
        }
    }
}
