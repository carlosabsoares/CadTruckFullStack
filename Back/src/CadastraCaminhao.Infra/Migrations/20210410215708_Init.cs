using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastraCaminhao.Infra.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tabTruck",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", nullable: false),
                    model = table.Column<int>(type: "varchar(2)", nullable: false),
                    yearOfManufacture = table.Column<int>(type: "int(4)", nullable: false),
                    modelYear = table.Column<int>(type: "int(4)", nullable: false),
                    color = table.Column<string>(type: "varchar(20)", nullable: true),
                    image = table.Column<string>(type: "varchar(80)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabTruck", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tabTruck_id",
                table: "tabTruck",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tabTruck");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
