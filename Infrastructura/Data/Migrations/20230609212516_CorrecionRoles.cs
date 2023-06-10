using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosRoles_Rol_RoleId",
                table: "UsuariosRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosRoles_Usuario_RoleId",
                table: "UsuariosRoles");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UsuariosRoles",
                newName: "RolId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuariosRoles_RoleId",
                table: "UsuariosRoles",
                newName: "IX_UsuariosRoles_RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosRoles_Rol_RolId",
                table: "UsuariosRoles",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosRoles_Usuario_RolId",
                table: "UsuariosRoles",
                column: "RolId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosRoles_Rol_RolId",
                table: "UsuariosRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosRoles_Usuario_RolId",
                table: "UsuariosRoles");

            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "UsuariosRoles",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuariosRoles_RolId",
                table: "UsuariosRoles",
                newName: "IX_UsuariosRoles_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosRoles_Rol_RoleId",
                table: "UsuariosRoles",
                column: "RoleId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosRoles_Usuario_RoleId",
                table: "UsuariosRoles",
                column: "RoleId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
