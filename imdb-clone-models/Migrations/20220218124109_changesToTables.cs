using Microsoft.EntityFrameworkCore.Migrations;

namespace imdb_clone_models.Migrations
{
    public partial class changesToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Movies_MovieId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MovieId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "MovieCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategories", x => new { x.MovieId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_MovieCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieCategories_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategories_CategoryId",
                table: "MovieCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCategories");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MovieId",
                table: "Categories",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Movies_MovieId",
                table: "Categories",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
