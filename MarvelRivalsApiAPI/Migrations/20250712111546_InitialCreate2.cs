using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelRivalsApiAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScoreInfoId",
                table: "MatchHistory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ScoreInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lose = table.Column<int>(type: "int", nullable: false),
                    Win = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchHistory_ScoreInfoId",
                table: "MatchHistory",
                column: "ScoreInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchHistory_ScoreInfo_ScoreInfoId",
                table: "MatchHistory",
                column: "ScoreInfoId",
                principalTable: "ScoreInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchHistory_ScoreInfo_ScoreInfoId",
                table: "MatchHistory");

            migrationBuilder.DropTable(
                name: "ScoreInfo");

            migrationBuilder.DropIndex(
                name: "IX_MatchHistory_ScoreInfoId",
                table: "MatchHistory");

            migrationBuilder.DropColumn(
                name: "ScoreInfoId",
                table: "MatchHistory");
        }
    }
}
