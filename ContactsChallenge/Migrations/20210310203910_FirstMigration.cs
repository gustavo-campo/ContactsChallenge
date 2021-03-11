using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsChallenge.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Company", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "JuanPerez S.A.", "juan@juanperezsa.com", "Juan", "Perez", "15-2222-3555" },
                    { 2, "Estudio Contable", "maria@estudiocontable.com", "Maria", "Martinez", "11-4454-4545" },
                    { 3, "Seguridad S.A.", "seguridad@seguridad.com", "Sebastian", "Gimenez", "11-2321-4878" },
                    { 4, "JuanPerez S.A.", "pedro@juanperezsa.com", "Pedro", "Lopez", "11-2233-4460" },
                    { 5, "JuanPerez S.A.", "Ramiro@juanperezsa.com", "Ramiro", "Estevez", "11-2233-4460" },
                    { 6, "EstebanSoft", "josefina@estebansoft.com", "Josefina", "Gomez", "11-2233-4460" },
                    { 7, "Roman Sanchez Contador", "RomanSanchezContador@gmail.com", "Roman", "Sanchez", "11-4453-4340" },
                    { 8, "Remises y Transportes S.A.", "mariopomez@gmail.com", "Mario", "Pomez", "11-2211-2222" },
                    { 9, "Juan Perez S.A.", "pepe@juanperezsa.com", "Tito", "Perez", "11-5555-2222" },
                    { 10, "Juan Perez S.A.", "Sofia@juanperezsa.com", "Sofia", "Perez", "11-5555-2222" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
