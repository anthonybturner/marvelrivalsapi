using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelRivalsApiAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddIdToMatchDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchDetail_GameMode_GameModeId",
                table: "MatchDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayer_MatchDetail_MatchDetailsId",
                table: "MatchPlayer");

            migrationBuilder.DropIndex(
                name: "IX_MatchPlayer_MatchDetailsId",
                table: "MatchPlayer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameMode",
                table: "GameMode");

            migrationBuilder.DropColumn(
                name: "MatchDetailsId",
                table: "MatchPlayer");

            migrationBuilder.AlterColumn<int>(
                name: "GameModeId",
                table: "GameMode",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GameMode",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameMode",
                table: "GameMode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchDetail_GameMode_GameModeId",
                table: "MatchDetail",
                column: "GameModeId",
                principalTable: "GameMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchDetail_GameMode_GameModeId",
                table: "MatchDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameMode",
                table: "GameMode");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GameMode");

            migrationBuilder.AddColumn<int>(
                name: "MatchDetailsId",
                table: "MatchPlayer",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GameModeId",
                table: "GameMode",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameMode",
                table: "GameMode",
                column: "GameModeId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_MatchDetailsId",
                table: "MatchPlayer",
                column: "MatchDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchDetail_GameMode_GameModeId",
                table: "MatchDetail",
                column: "GameModeId",
                principalTable: "GameMode",
                principalColumn: "GameModeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayer_MatchDetail_MatchDetailsId",
                table: "MatchPlayer",
                column: "MatchDetailsId",
                principalTable: "MatchDetail",
                principalColumn: "Id");
        }
    }
}
