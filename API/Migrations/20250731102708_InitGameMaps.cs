using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelRivals.Migrations
{
    /// <inheritdoc />
    public partial class InitGameMaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ability_Heroes_HeroId",
                table: "Ability");

            migrationBuilder.DropForeignKey(
                name: "FK_Costumes_Heroes_HeroId",
                table: "Costumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transformations_Heroes_HeroId",
                table: "Transformations");

            migrationBuilder.AlterColumn<string>(
                name: "HeroId",
                table: "Transformations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "HeroId",
                table: "Costumes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CostumeId",
                table: "Costumes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HeroId",
                table: "Ability",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "SubMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubMapId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameMapId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompetitive = table.Column<bool>(type: "bit", nullable: false),
                    SubMapId = table.Column<int>(type: "int", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameMaps_SubMap_SubMapId",
                        column: x => x.SubMapId,
                        principalTable: "SubMap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameMaps_SubMapId",
                table: "GameMaps",
                column: "SubMapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ability_Heroes_HeroId",
                table: "Ability",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Costumes_Heroes_HeroId",
                table: "Costumes",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transformations_Heroes_HeroId",
                table: "Transformations",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ability_Heroes_HeroId",
                table: "Ability");

            migrationBuilder.DropForeignKey(
                name: "FK_Costumes_Heroes_HeroId",
                table: "Costumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transformations_Heroes_HeroId",
                table: "Transformations");

            migrationBuilder.DropTable(
                name: "GameMaps");

            migrationBuilder.DropTable(
                name: "SubMap");

            migrationBuilder.AlterColumn<string>(
                name: "HeroId",
                table: "Transformations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeroId",
                table: "Costumes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CostumeId",
                table: "Costumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HeroId",
                table: "Ability",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ability_Heroes_HeroId",
                table: "Ability",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Costumes_Heroes_HeroId",
                table: "Costumes",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transformations_Heroes_HeroId",
                table: "Transformations",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
