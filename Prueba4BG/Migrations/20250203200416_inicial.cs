using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba4BG.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    operacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor1 = table.Column<int>(type: "int", nullable: false),
                    valor2 = table.Column<int>(type: "int", nullable: false),
                    resultado = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operaciones");
        }
    }
}
