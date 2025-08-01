using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelRivalsApiAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMarvelRivalsChange4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchDetailsId",
                table: "MatchPlayer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameMode",
                columns: table => new
                {
                    GameModeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameModeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMode", x => x.GameModeId);
                });

            migrationBuilder.CreateTable(
                name: "MatchDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchUid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameModeId = table.Column<int>(type: "int", nullable: false),
                    ReplayId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MvpUid = table.Column<long>(type: "bigint", nullable: false),
                    MvpHeroId = table.Column<int>(type: "int", nullable: false),
                    SvpUid = table.Column<long>(type: "bigint", nullable: false),
                    SvpHeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchDetail_GameMode_GameModeId",
                        column: x => x.GameModeId,
                        principalTable: "GameMode",
                        principalColumn: "GameModeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_MatchDetailsId",
                table: "MatchPlayer",
                column: "MatchDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchDetail_GameModeId",
                table: "MatchDetail",
                column: "GameModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayer_MatchDetail_MatchDetailsId",
                table: "MatchPlayer",
                column: "MatchDetailsId",
                principalTable: "MatchDetail",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayer_MatchDetail_MatchDetailsId",
                table: "MatchPlayer");

            migrationBuilder.DropTable(
                name: "MatchDetail");

            migrationBuilder.DropTable(
                name: "GameMode");

            migrationBuilder.DropIndex(
                name: "IX_MatchPlayer_MatchDetailsId",
                table: "MatchPlayer");

            migrationBuilder.DropColumn(
                name: "MatchDetailsId",
                table: "MatchPlayer");
        }
    }
}
