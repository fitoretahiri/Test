using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_delivery_app_LabCouse1.Migrations
{
    public partial class addRestaurantToDatabaseUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Menu_menuID",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_menuID",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "menuID",
                table: "Restaurant");

            migrationBuilder.AddColumn<int>(
                name: "restaurantID",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_restaurantID",
                table: "Menu",
                column: "restaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Restaurant_restaurantID",
                table: "Menu",
                column: "restaurantID",
                principalTable: "Restaurant",
                principalColumn: "restaurantID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Restaurant_restaurantID",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_restaurantID",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "restaurantID",
                table: "Menu");

            migrationBuilder.AddColumn<int>(
                name: "menuID",
                table: "Restaurant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_menuID",
                table: "Restaurant",
                column: "menuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Menu_menuID",
                table: "Restaurant",
                column: "menuID",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
