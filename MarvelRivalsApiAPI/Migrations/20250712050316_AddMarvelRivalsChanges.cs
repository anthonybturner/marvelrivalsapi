using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelRivalsApiAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMarvelRivalsChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchHistories_MatchPlayer_MatchPlayerId",
                table: "MatchHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchHistories",
                table: "MatchHistories");

            migrationBuilder.RenameTable(
                name: "MatchHistories",
                newName: "MatchHistory");

            migrationBuilder.RenameIndex(
                name: "IX_MatchHistories_MatchPlayerId",
                table: "MatchHistory",
                newName: "IX_MatchHistory_MatchPlayerId");

            migrationBuilder.AlterColumn<string>(
                name: "Kills",
                table: "PlayerHero",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HeroType",
                table: "PlayerHero",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HeroName",
                table: "PlayerHero",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Deaths",
                table: "PlayerHero",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Assists",
                table: "PlayerHero",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerUid",
                table: "MatchPlayer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                table: "MatchPlayer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MatchPlayerId",
                table: "MatchHistory",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchHistory",
                table: "MatchHistory",
                column: "MatchMapId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchHistory_MatchPlayer_MatchPlayerId",
                table: "MatchHistory",
                column: "MatchPlayerId",
                principalTable: "MatchPlayer",
                principalColumn: "PlayerUid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchHistory_MatchPlayer_MatchPlayerId",
                table: "MatchHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchHistory",
                table: "MatchHistory");

            migrationBuilder.DropColumn(
                name: "PlayerName",
                table: "MatchPlayer");

            migrationBuilder.RenameTable(
                name: "MatchHistory",
                newName: "MatchHistories");

            migrationBuilder.RenameIndex(
                name: "IX_MatchHistory_MatchPlayerId",
                table: "MatchHistories",
                newName: "IX_MatchHistories_MatchPlayerId");

            migrationBuilder.AlterColumn<string>(
                name: "Kills",
                table: "PlayerHero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeroType",
                table: "PlayerHero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeroName",
                table: "PlayerHero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Deaths",
                table: "PlayerHero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Assists",
                table: "PlayerHero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerUid",
                table: "MatchPlayer",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "MatchPlayerId",
                table: "MatchHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchHistories",
                table: "MatchHistories",
                column: "MatchMapId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchHistories_MatchPlayer_MatchPlayerId",
                table: "MatchHistories",
                column: "MatchPlayerId",
                principalTable: "MatchPlayer",
                principalColumn: "PlayerUid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
