using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_delivery_app_LabCouse1.Migrations
{
    public partial class addTransportuesiToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transportuesi",
                columns: table => new
                {
                    transportuesiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nrPorosive = table.Column<int>(type: "int", nullable: false),
                    dataLindjes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    statusi_aktivitetit = table.Column<int>(type: "int", nullable: false),
                    perdoruesiID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportuesi", x => x.transportuesiID);
                    table.ForeignKey(
                        name: "FK_Transportuesi_Perdoruesi_perdoruesiID",
                        column: x => x.perdoruesiID,
                        principalTable: "Perdoruesi",
                        principalColumn: "perdoruesiID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transportuesi_perdoruesiID",
                table: "Transportuesi",
                column: "perdoruesiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transportuesi");
        }
    }
}
