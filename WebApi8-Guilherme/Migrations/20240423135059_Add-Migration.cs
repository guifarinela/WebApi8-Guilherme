using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi8_Guilherme.Migrations
{
    /// <inheritdoc />
    public partial class AddMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "Autor",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Autor",
                newName: "LastName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Autor",
                newName: "Sobrenome");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Autor",
                newName: "Nome");
        }
    }
}
