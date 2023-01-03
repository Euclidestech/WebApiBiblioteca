using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    public partial class atualizacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Pedidos_PedidoId",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfilUsuario_Perfils_PerfilsId",
                table: "PerfilUsuario");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "PerfilsId",
                table: "PerfilUsuario",
                newName: "PerfisId");

            migrationBuilder.RenameColumn(
                name: "LivrosId",
                table: "Pedidos",
                newName: "LivroId");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "Livros",
                newName: "usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Livros_PedidoId",
                table: "Livros",
                newName: "IX_Livros_usuarioId");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_LivroId",
                table: "Pedidos",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Usuarios_usuarioId",
                table: "Livros",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Livros_LivroId",
                table: "Pedidos",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUsuario_Perfils_PerfisId",
                table: "PerfilUsuario",
                column: "PerfisId",
                principalTable: "Perfils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Usuarios_usuarioId",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Livros_LivroId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfilUsuario_Perfils_PerfisId",
                table: "PerfilUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_LivroId",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "PerfisId",
                table: "PerfilUsuario",
                newName: "PerfilsId");

            migrationBuilder.RenameColumn(
                name: "LivroId",
                table: "Pedidos",
                newName: "LivrosId");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "Livros",
                newName: "PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_Livros_usuarioId",
                table: "Livros",
                newName: "IX_Livros_PedidoId");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Pedidos_PedidoId",
                table: "Livros",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilUsuario_Perfils_PerfilsId",
                table: "PerfilUsuario",
                column: "PerfilsId",
                principalTable: "Perfils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
