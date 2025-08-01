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
                    IsWinInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IsWin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsWinInfo", x => x.IsWinInfoId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerScoreInfo",
                columns: table => new
                {
                    PlayerScoreInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    addScore = table.Column<int>(type: "int", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false),
                    newLevel = table.Column<int>(type: "int", nullable: false),
                    newScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerScoreInfo", x => x.PlayerScoreInfoId);
                });

            migrationBuilder.CreateTable(
                name: "PlayTime",
                columns: table => new
                {
                    PlayTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    raw = table.Column<int>(type: "int", nullable: false),
                    formatted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayTime", x => x.PlayTimeId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerHero",
                columns: table => new
                {
                    HeroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deaths = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assists = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayTimeId = table.Column<int>(type: "int", nullable: false),
                    TotalHeroDamage = table.Column<int>(type: "int", nullable: false),
                    TotalDamageTaken = table.Column<int>(type: "int", nullable: false),
                    TotalHeroHeal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerHero", x => x.HeroId);
                    table.ForeignKey(
                        name: "FK_PlayerHero_PlayTime_PlayTimeId",
                        column: x => x.PlayTimeId,
                        principalTable: "PlayTime",
                        principalColumn: "PlayTimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchPlayer",
                columns: table => new
                {
                    PlayerUid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    IsWinId = table.Column<int>(type: "int", nullable: false),
                    Disconnected = table.Column<bool>(type: "bit", nullable: false),
                    Camp = table.Column<int>(type: "int", nullable: true),
                    ScoreInfoId = table.Column<int>(type: "int", nullable: false),
                    PlayerHeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayer", x => x.PlayerUid);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_IsWinInfo_IsWinId",
                        column: x => x.IsWinId,
                        principalTable: "IsWinInfo",
                        principalColumn: "IsWinInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_PlayerHero_PlayerHeroId",
                        column: x => x.PlayerHeroId,
                        principalTable: "PlayerHero",
                        principalColumn: "HeroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_PlayerScoreInfo_ScoreInfoId",
                        column: x => x.ScoreInfoId,
                        principalTable: "PlayerScoreInfo",
                        principalColumn: "PlayerScoreInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchHistories",
                columns: table => new
                {
                    MatchMapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchMapName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapThumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchPlayDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchSeason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchUid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchWinnerSide = table.Column<int>(type: "int", nullable: false),
                    MvpUid = table.Column<int>(type: "int", nullable: false),
                    SvpUid = table.Column<int>(type: "int", nullable: false),
                    ScoreInfoJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchTimeStamp = table.Column<long>(type: "bigint", nullable: false),
                    PlayModeId = table.Column<int>(type: "int", nullable: false),
                    GameModeId = table.Column<int>(type: "int", nullable: false),
                    MatchPlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchHistories", x => x.MatchMapId);
                    table.ForeignKey(
                        name: "FK_MatchHistories_MatchPlayer_MatchPlayerId",
                        column: x => x.MatchPlayerId,
                        principalTable: "MatchPlayer",
                        principalColumn: "PlayerUid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchHistories_MatchPlayerId",
                table: "MatchHistories",
                column: "MatchPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_IsWinId",
                table: "MatchPlayer",
                column: "IsWinId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_PlayerHeroId",
                table: "MatchPlayer",
                column: "PlayerHeroId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_ScoreInfoId",
                table: "MatchPlayer",
                column: "ScoreInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerHero_PlayTimeId",
                table: "PlayerHero",
                column: "PlayTimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchHistories");

            migrationBuilder.DropTable(
                name: "MatchPlayer");

            migrationBuilder.DropTable(
                name: "IsWinInfo");

            migrationBuilder.DropTable(
                name: "PlayerHero");

            migrationBuilder.DropTable(
                name: "PlayerScoreInfo");

            migrationBuilder.DropTable(
                name: "PlayTime");
        }
    }
}
