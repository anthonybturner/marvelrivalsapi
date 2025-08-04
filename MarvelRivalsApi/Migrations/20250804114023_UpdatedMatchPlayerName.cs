using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelRivalsApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMatchPlayerName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayerName",
                table: "MatchHistory",
                newName: "MatchPlayerName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MatchPlayerName",
                table: "MatchHistory",
                newName: "PlayerName");
        }
    }
}
