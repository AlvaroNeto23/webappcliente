using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCliente.Migrations
{
    public partial class RelacionamentoLogradouroCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Logradouros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logradouros_ClienteId",
                table: "Logradouros",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logradouros_Clientes_ClienteId",
                table: "Logradouros",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logradouros_Clientes_ClienteId",
                table: "Logradouros");

            migrationBuilder.DropIndex(
                name: "IX_Logradouros_ClienteId",
                table: "Logradouros");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Logradouros");
        }
    }
}
