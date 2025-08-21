using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarvelRivalsApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAbilitiesAndCustomes4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quality",
                table: "Costume");

            migrationBuilder.AddColumn<int>(
                name: "QualityId",
                table: "Costume",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Quality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quality", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Costume_QualityId",
                table: "Costume",
                column: "QualityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Costume_Quality_QualityId",
                table: "Costume",
                column: "QualityId",
                principalTable: "Quality",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costume_Quality_QualityId",
                table: "Costume");

            migrationBuilder.DropTable(
                name: "Quality");

            migrationBuilder.DropIndex(
                name: "IX_Costume_QualityId",
                table: "Costume");

            migrationBuilder.DropColumn(
                name: "QualityId",
                table: "Costume");

            migrationBuilder.AddColumn<string>(
                name: "Quality",
                table: "Costume",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
