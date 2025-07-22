using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelRivalsApiAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddIdToMatchDetail2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIBadge");

            migrationBuilder.CreateTable(
                name: "Badge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BadgeId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    MatchDetailsPlayersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Badge_MatchDetailsPlayers_MatchDetailsPlayersId",
                        column: x => x.MatchDetailsPlayersId,
                        principalTable: "MatchDetailsPlayers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Badge_MatchDetailsPlayersId",
                table: "Badge",
                column: "MatchDetailsPlayersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.CreateTable(
                name: "APIBadge",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BadgeId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    MatchDetailsPlayersId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIBadge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_APIBadge_MatchDetailsPlayers_MatchDetailsPlayersId",
                        column: x => x.MatchDetailsPlayersId,
                        principalTable: "MatchDetailsPlayers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_APIBadge_MatchDetailsPlayersId",
                table: "APIBadge",
                column: "MatchDetailsPlayersId");
        }
    }
}
