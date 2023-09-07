using Microsoft.EntityFrameworkCore.Migrations;

namespace Raspored.Migrations
{
    public partial class Rolefeaturemappinginitialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeatureTypeId",
                table: "RoleFeatureMappings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Features",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Features",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FeatureTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FeatureTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "RCDatumSmene" },
                    { 1, "Raspored" },
                    { 2, "Timovi" },
                    { 3, "Zaposleni" },
                    { 8, "RCSmena" },
                    { 5, "Profil" },
                    { 6, "RCZaglavlje" },
                    { 7, "RCImeClana" },
                    { 4, "Podešavanja" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 20, "Izmeni podatke u zaglavlju izabranog rasporeda", "Izmeni" },
                    { 27, "Izmena smene za ceo tim", "Izmeni smenu" },
                    { 26, "Dodela smene za ceo tim", "Dodeli smenu" },
                    { 25, "Brisanje smene sa rasporeda", "Obriši smenu" },
                    { 24, "Promena tipa smene", "Promeni smenu" },
                    { 23, "Dodavanje smene zaposlenom", "Dodaj smenu" },
                    { 22, "Prebacivanje zaposlenog u drugi tim", "Prebaci u drugi tim" },
                    { 21, "Dodavanje / promena uloge u sklopu tima", "Dodaj/promeni ulogu" },
                    { 28, "Brisanje smene za ceo tim", "Obriši smenu" },
                    { 19, "Izmena osnovnih podataka korisnika", "Izmena" },
                    { 17, "Podešavanja organizacije timova", "Timovi" },
                    { 2, "Timski raspored za tekući mesec", "Timski" },
                    { 3, "Pregled svih timskih rasporeda za tekući mesec", "Odeljenski" },
                    { 4, "Brzi pregled svih tehničara u timu po datumu i smeni", "Smenski" },
                    { 5, "Kreiranje rasporeda za naredni mesec za sve timove", "Kreiraj" },
                    { 6, "Lista postojećih timova", "Lista" },
                    { 7, "Dodavanje novog tima", "Dodaj" },
                    { 8, "Izmena postojećeg tima", "Izmeni" },
                    { 9, "Brisanje postojećeg tima", "Obriši" },
                    { 10, "Spisak svih zaposlenih", "Lista" },
                    { 11, "Dodaj novog zaposlenog", "Dodaj" },
                    { 12, "Izmena podataka zaposlenih", "Izmeni" },
                    { 13, "Obriši zaposlenog - podaci se arhiviraju!", "Obriši" },
                    { 14, "Pretraga zaposlenih po različitim kriterijumima", "Pretraga" },
                    { 15, "Podešavanja izgleda i funkcionalnosti aplikacije", "Aplikacija" },
                    { 16, "Administrativna podešavanja aplikacije i podataka", "Administracija" },
                    { 18, "Prikaz osnovnih podataka korisnika", "Prikaz" },
                    { 1, "Lični raspored za tekući mesec", "Lični" }
                });

            migrationBuilder.InsertData(
                table: "RoleFeatureMappings",
                columns: new[] { "Id", "FeatureId", "FeatureTypeId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, 1, "95df2068-389d-457f-a0e6-eb8b4e1bc906" },
                    { 20, 15, 4, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 21, 16, 4, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 22, 17, 4, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 23, 18, 5, "95df2068-389d-457f-a0e6-eb8b4e1bc906" },
                    { 24, 19, 5, "95df2068-389d-457f-a0e6-eb8b4e1bc906" },
                    { 25, 18, 5, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 19, 15, 4, "95df2068-389d-457f-a0e6-eb8b4e1bc906" },
                    { 26, 19, 5, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 28, 21, 7, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 29, 22, 7, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 30, 23, 8, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 31, 24, 8, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 32, 25, 8, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 33, 26, 9, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 27, 20, 6, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 34, 27, 9, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 18, 14, 3, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 16, 12, 3, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 2, 2, 1, "95df2068-389d-457f-a0e6-eb8b4e1bc906" },
                    { 3, 3, 1, "95df2068-389d-457f-a0e6-eb8b4e1bc906" },
                    { 4, 4, 1, "95df2068-389d-457f-a0e6-eb8b4e1bc906" },
                    { 5, 1, 1, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 6, 2, 1, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 7, 3, 1, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 17, 13, 3, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 8, 4, 1, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 10, 6, 2, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 11, 7, 2, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 12, 8, 2, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 13, 9, 2, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 14, 10, 3, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 15, 11, 3, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 9, 5, 1, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" },
                    { 35, 28, 9, "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleFeatureMappings_FeatureTypeId",
                table: "RoleFeatureMappings",
                column: "FeatureTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleFeatureMappings_FeatureTypes_FeatureTypeId",
                table: "RoleFeatureMappings",
                column: "FeatureTypeId",
                principalTable: "FeatureTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleFeatureMappings_FeatureTypes_FeatureTypeId",
                table: "RoleFeatureMappings");

            migrationBuilder.DropTable(
                name: "FeatureTypes");

            migrationBuilder.DropIndex(
                name: "IX_RoleFeatureMappings_FeatureTypeId",
                table: "RoleFeatureMappings");

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "RoleFeatureMappings",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DropColumn(
                name: "FeatureTypeId",
                table: "RoleFeatureMappings");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
