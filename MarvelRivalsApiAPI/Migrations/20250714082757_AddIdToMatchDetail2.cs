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
            migrationBuilder.AddColumn<int>(
                name: "MatchDetailsPlayersId",
                table: "PlayerHero",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MatchDetailsPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerUid = table.Column<long>(type: "bigint", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerIcon = table.Column<long>(type: "bigint", nullable: false),
                    Camp = table.Column<int>(type: "int", nullable: false),
                    CurHeroId = table.Column<int>(type: "int", nullable: false),
                    CurHeroIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsWin = table.Column<int>(type: "int", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    TotalHeroDamage = table.Column<double>(type: "float", nullable: false),
                    TotalHeroHeal = table.Column<double>(type: "float", nullable: false),
                    TotalDamageTaken = table.Column<double>(type: "float", nullable: false),
                    MatchDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchDetailsPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchDetailsPlayers_MatchDetail_MatchDetailsId",
                        column: x => x.MatchDetailsId,
                        principalTable: "MatchDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "APIBadge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    MatchDetailsPlayersId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_PlayerHero_MatchDetailsPlayersId",
                table: "PlayerHero",
                column: "MatchDetailsPlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_APIBadge_MatchDetailsPlayersId",
                table: "APIBadge",
                column: "MatchDetailsPlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchDetailsPlayers_MatchDetailsId",
                table: "MatchDetailsPlayers",
                column: "MatchDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerHero_MatchDetailsPlayers_MatchDetailsPlayersId",
                table: "PlayerHero",
                column: "MatchDetailsPlayersId",
                principalTable: "MatchDetailsPlayers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerHero_MatchDetailsPlayers_MatchDetailsPlayersId",
                table: "PlayerHero");

            migrationBuilder.DropTable(
                name: "APIBadge");

            migrationBuilder.DropTable(
                name: "MatchDetailsPlayers");

            migrationBuilder.DropIndex(
                name: "IX_PlayerHero_MatchDetailsPlayersId",
                table: "PlayerHero");

            migrationBuilder.DropColumn(
                name: "MatchDetailsPlayersId",
                table: "PlayerHero");
        }
    }
}
