using Microsoft.EntityFrameworkCore.Migrations;

namespace MilionarFINAL.Data.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ID_Otazka",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "StavHry",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "kolo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Otazky",
                columns: table => new
                {
                    OtazkaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    textOtazka = table.Column<string>(nullable: false),
                    Narocnost = table.Column<int>(nullable: false),
                    Odpoved = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otazky", x => x.OtazkaID);
                });

            migrationBuilder.CreateTable(
                name: "OdpovediUzivatelu",
                columns: table => new
                {
                    ID_OdpovedUzivatele = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Spravnost = table.Column<bool>(nullable: false),
                    ID_Otazka = table.Column<int>(nullable: false),
                    ID_Uzivatel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdpovediUzivatelu", x => x.ID_OdpovedUzivatele);
                    table.ForeignKey(
                        name: "FK_OdpovediUzivatelu_Otazky_ID_Otazka",
                        column: x => x.ID_Otazka,
                        principalTable: "Otazky",
                        principalColumn: "OtazkaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdpovediUzivatelu_AspNetUsers_ID_Uzivatel",
                        column: x => x.ID_Uzivatel,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ID_Otazka",
                table: "AspNetUsers",
                column: "ID_Otazka");

            migrationBuilder.CreateIndex(
                name: "IX_OdpovediUzivatelu_ID_Otazka",
                table: "OdpovediUzivatelu",
                column: "ID_Otazka");

            migrationBuilder.CreateIndex(
                name: "IX_OdpovediUzivatelu_ID_Uzivatel",
                table: "OdpovediUzivatelu",
                column: "ID_Uzivatel");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Otazky_ID_Otazka",
                table: "AspNetUsers",
                column: "ID_Otazka",
                principalTable: "Otazky",
                principalColumn: "OtazkaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Otazky_ID_Otazka",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OdpovediUzivatelu");

            migrationBuilder.DropTable(
                name: "Otazky");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ID_Otazka",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ID_Otazka",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StavHry",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "kolo",
                table: "AspNetUsers");
        }
    }
}
