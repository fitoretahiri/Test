using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_delivery_app_LabCouse1.Migrations
{
    public partial class addRestaurantToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    restaurantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_regjistrimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    menuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.restaurantID);
                    table.ForeignKey(
                        name: "FK_Restaurant_Menu_menuID",
                        column: x => x.menuID,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "restaurant_Qyteti",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    restaurantID = table.Column<int>(type: "int", nullable: false),
                    qytetiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurant_Qyteti", x => x.id);
                    table.ForeignKey(
                        name: "FK_restaurant_Qyteti_Qyteti_qytetiID",
                        column: x => x.qytetiID,
                        principalTable: "Qyteti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_restaurant_Qyteti_Restaurant_restaurantID",
                        column: x => x.restaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "restaurantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_menuID",
                table: "Restaurant",
                column: "menuID");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_Qyteti_qytetiID",
                table: "restaurant_Qyteti",
                column: "qytetiID");

            migrationBuilder.CreateIndex(
                name: "IX_restaurant_Qyteti_restaurantID",
                table: "restaurant_Qyteti",
                column: "restaurantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "restaurant_Qyteti");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.CreateTable(
                name: "Restoranti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_regjistrimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    emri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nr_kontaktues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qyteti = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restoranti", x => x.Id);
                });
        }
    }
}