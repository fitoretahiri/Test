using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_delivery_app_LabCouse1.Migrations
{
    public partial class addRestaurantToDatabaseUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "perdoruesiID",
                table: "Restaurant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_perdoruesiID",
                table: "Restaurant",
                column: "perdoruesiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Perdoruesi_perdoruesiID",
                table: "Restaurant",
                column: "perdoruesiID",
                principalTable: "Perdoruesi",
                principalColumn: "perdoruesiID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Perdoruesi_perdoruesiID",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_perdoruesiID",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "perdoruesiID",
                table: "Restaurant");
        }
    }
}
