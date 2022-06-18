using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_delivery_app_LabCouse1.Migrations
{
    public partial class addKlientiToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienti",
                columns: table => new
                {
                    klientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nrPorosive = table.Column<int>(type: "int", nullable: false),
                    dataLindjes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    perdoruesiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienti", x => x.klientID);
                    table.ForeignKey(
                        name: "FK_Klienti_Perdoruesi_perdoruesiID",
                        column: x => x.perdoruesiID,
                        principalTable: "Perdoruesi",
                        principalColumn: "perdoruesiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klienti_perdoruesiID",
                table: "Klienti",
                column: "perdoruesiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klienti");
        }
    }
}
