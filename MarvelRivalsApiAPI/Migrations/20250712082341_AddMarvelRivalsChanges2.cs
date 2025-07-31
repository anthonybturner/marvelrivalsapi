using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelRivalsApiAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMarvelRivalsChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchHistory_MatchPlayer_MatchPlayerId",
                table: "MatchHistory");

            migrationBuilder.RenameColumn(
                name: "MatchPlayerId",
                table: "MatchHistory",
                newName: "MatchPlayerPlayerUid");

            migrationBuilder.RenameIndex(
                name: "IX_MatchHistory_MatchPlayerId",
                table: "MatchHistory",
                newName: "IX_MatchHistory_MatchPlayerPlayerUid");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchHistory_MatchPlayer_MatchPlayerPlayerUid",
                table: "MatchHistory",
                column: "MatchPlayerPlayerUid",
                principalTable: "MatchPlayer",
                principalColumn: "PlayerUid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchHistory_MatchPlayer_MatchPlayerPlayerUid",
                table: "MatchHistory");

            migrationBuilder.RenameColumn(
                name: "MatchPlayerPlayerUid",
                table: "MatchHistory",
                newName: "MatchPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchHistory_MatchPlayerPlayerUid",
                table: "MatchHistory",
                newName: "IX_MatchHistory_MatchPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchHistory_MatchPlayer_MatchPlayerId",
                table: "MatchHistory",
                column: "MatchPlayerId",
                principalTable: "MatchPlayer",
                principalColumn: "PlayerUid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
