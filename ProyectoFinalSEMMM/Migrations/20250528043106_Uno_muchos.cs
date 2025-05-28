using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalSEMMM.Migrations
{
    /// <inheritdoc />
    public partial class Uno_muchos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_AutorId",
                table: "Libros",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_AutorId",
                table: "Libros",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_AutorId",
                table: "Libros");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Libros_AutorId",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Libros");
        }
    }
}
