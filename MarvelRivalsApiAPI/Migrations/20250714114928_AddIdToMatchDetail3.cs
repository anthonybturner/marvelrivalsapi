using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelRivalsApiAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddIdToMatchDetail3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Badge",
                newName: "BadgesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BadgesId",
                table: "Badge",
                newName: "Id");
        }
    }
}
