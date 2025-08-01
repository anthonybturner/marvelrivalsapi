using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelRivals.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHeroTransformationRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costumes_Heroes_HeroId",
                table: "Costumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transformations_Heroes_HeroId",
                table: "Transformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transformations",
                table: "Transformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Costumes",
                table: "Costumes");

            migrationBuilder.RenameTable(
                name: "Transformations",
                newName: "Transformation");

            migrationBuilder.RenameTable(
                name: "Costumes",
                newName: "Costume");

            migrationBuilder.RenameIndex(
                name: "IX_Transformations_HeroId",
                table: "Transformation",
                newName: "IX_Transformation_HeroId");

            migrationBuilder.RenameIndex(
                name: "IX_Costumes_HeroId",
                table: "Costume",
                newName: "IX_Costume_HeroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transformation",
                table: "Transformation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Costume",
                table: "Costume",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Costume_Heroes_HeroId",
                table: "Costume",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transformation_Heroes_HeroId",
                table: "Transformation",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costume_Heroes_HeroId",
                table: "Costume");

            migrationBuilder.DropForeignKey(
                name: "FK_Transformation_Heroes_HeroId",
                table: "Transformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transformation",
                table: "Transformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Costume",
                table: "Costume");

            migrationBuilder.RenameTable(
                name: "Transformation",
                newName: "Transformations");

            migrationBuilder.RenameTable(
                name: "Costume",
                newName: "Costumes");

            migrationBuilder.RenameIndex(
                name: "IX_Transformation_HeroId",
                table: "Transformations",
                newName: "IX_Transformations_HeroId");

            migrationBuilder.RenameIndex(
                name: "IX_Costume_HeroId",
                table: "Costumes",
                newName: "IX_Costumes_HeroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transformations",
                table: "Transformations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Costumes",
                table: "Costumes",
                column: "Id");

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
    }
}
