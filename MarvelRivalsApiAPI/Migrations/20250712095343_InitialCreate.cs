using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelRivalsApiAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IsWinInfo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IsWin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsWinInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerHero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroId = table.Column<int>(type: "int", nullable: false),
                    HeroName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deaths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assists = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayTimeId = table.Column<int>(type: "int", nullable: false),
                    TotalHeroDamage = table.Column<int>(type: "int", nullable: false),
                    TotalDamageTaken = table.Column<int>(type: "int", nullable: false),
                    TotalHeroHeal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerHero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerScoreInfo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    addScore = table.Column<int>(type: "int", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false),
                    newLevel = table.Column<int>(type: "int", nullable: false),
                    newScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerScoreInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MatchPlayer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerUid = table.Column<int>(type: "int", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    IsWinId = table.Column<int>(type: "int", nullable: false),
                    Disconnected = table.Column<bool>(type: "bit", nullable: false),
                    Camp = table.Column<int>(type: "int", nullable: true),
                    ScoreInfoid = table.Column<int>(type: "int", nullable: true),
                    PlayerHeroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayer", x => x.id);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_IsWinInfo_IsWinId",
                        column: x => x.IsWinId,
                        principalTable: "IsWinInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_PlayerHero_PlayerHeroId",
                        column: x => x.PlayerHeroId,
                        principalTable: "PlayerHero",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchPlayer_PlayerScoreInfo_ScoreInfoid",
                        column: x => x.ScoreInfoid,
                        principalTable: "PlayerScoreInfo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "MatchHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchMapId = table.Column<int>(type: "int", nullable: false),
                    MatchMapName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapThumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatchPlayDuration = table.Column<double>(type: "float", nullable: false),
                    MatchSeason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatchUid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatchWinnerSide = table.Column<int>(type: "int", nullable: false),
                    MvpUid = table.Column<int>(type: "int", nullable: false),
                    SvpUid = table.Column<int>(type: "int", nullable: false),
                    MatchTimeStamp = table.Column<long>(type: "bigint", nullable: false),
                    PlayModeId = table.Column<int>(type: "int", nullable: false),
                    GameModeId = table.Column<int>(type: "int", nullable: false),
                    MatchPlayerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchHistory_MatchPlayer_MatchPlayerid",
                        column: x => x.MatchPlayerid,
                        principalTable: "MatchPlayer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchHistory_MatchPlayerid",
                table: "MatchHistory",
                column: "MatchPlayerid");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_IsWinId",
                table: "MatchPlayer",
                column: "IsWinId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_PlayerHeroId",
                table: "MatchPlayer",
                column: "PlayerHeroId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_ScoreInfoid",
                table: "MatchPlayer",
                column: "ScoreInfoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchHistory");

            migrationBuilder.DropTable(
                name: "MatchPlayer");

            migrationBuilder.DropTable(
                name: "IsWinInfo");

            migrationBuilder.DropTable(
                name: "PlayerHero");

            migrationBuilder.DropTable(
                name: "PlayerScoreInfo");
        }
    }
}
