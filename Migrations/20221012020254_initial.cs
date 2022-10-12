using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAlimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAlimentos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Alimentos",
                columns: new[] { "Id", "Nome", "TipoID" },
                values: new object[,]
                {
                    { 1, "Maça", 1 },
                    { 2, "Alface", 2 }
                });

            migrationBuilder.InsertData(
                table: "TipoAlimentos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Fruta" },
                    { 2, "Verdura" },
                    { 3, "Legume" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimentos");

            migrationBuilder.DropTable(
                name: "TipoAlimentos");
        }
    }
}
