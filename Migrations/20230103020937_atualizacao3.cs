using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    public partial class atualizacao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Usuarios_usuarioId",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfilUsuario_Perfils_PerfisId",
                table: "PerfilUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Perfils",
                table: "Perfils");

            migrationBuilder.RenameTable(
                name: "Perfils",
                newName: "Perfis");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "Livros",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Livros_usuarioId",
                table: "Livros",
                newName: "IX_Livros_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Perfis",
                table: "Perfis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Usuarios_UsuarioId",
                table: "Livros",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUsuario_Perfis_PerfisId",
                table: "PerfilUsuario",
                column: "PerfisId",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Usuarios_UsuarioId",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfilUsuario_Perfis_PerfisId",
                table: "PerfilUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Perfis",
                table: "Perfis");

            migrationBuilder.RenameTable(
                name: "Perfis",
                newName: "Perfils");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Livros",
                newName: "usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Livros_UsuarioId",
                table: "Livros",
                newName: "IX_Livros_usuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Perfils",
                table: "Perfils",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Usuarios_usuarioId",
                table: "Livros",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUsuario_Perfils_PerfisId",
                table: "PerfilUsuario",
                column: "PerfisId",
                principalTable: "Perfils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
