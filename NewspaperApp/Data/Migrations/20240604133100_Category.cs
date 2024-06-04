using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewspaperApp.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Newspapers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Newspapers_CategoryId",
                table: "Newspapers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Newspapers_Categories_CategoryId",
                table: "Newspapers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Newspapers_Categories_CategoryId",
                table: "Newspapers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Newspapers_CategoryId",
                table: "Newspapers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Newspapers");
        }
    }
}
