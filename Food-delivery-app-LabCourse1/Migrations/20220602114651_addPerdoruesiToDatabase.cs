using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_delivery_app_LabCouse1.Migrations
{
    public partial class addPerdoruesiToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "Roli",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Perdoruesi",
                columns: table => new
                {
                    perdoruesiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nr_telefonit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photoProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roliID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perdoruesi", x => x.perdoruesiID);
                    table.ForeignKey(
                        name: "FK_Perdoruesi_Roli_roliID",
                        column: x => x.roliID,
                        principalTable: "Roli",
                        principalColumn: "roliID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perdoruesi_roliID",
                table: "Perdoruesi",
                column: "roliID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perdoruesi");

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "Roli",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
