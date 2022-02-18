using Microsoft.EntityFrameworkCore.Migrations;

namespace imdb_clone_models.Migrations
{
    public partial class updateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Files_Actors_Id",
                table: "Files",
                column: "Id",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Producers_Id",
                table: "Files",
                column: "Id",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Actors_Id",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Producers_Id",
                table: "Files");
        }
    }
}
