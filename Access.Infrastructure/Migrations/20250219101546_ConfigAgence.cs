using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Access.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigAgence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocieteAgences_Collaborateurs",
                table: "SocieteAgences");

            migrationBuilder.RenameColumn(
                name: "CollaborateurName",
                table: "SocieteAgences",
                newName: "ResponsableName");

            migrationBuilder.AlterColumn<int>(
                name: "CollaborateurId",
                table: "SocieteAgences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ResponsableEmail",
                table: "SocieteAgences",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResponsableTel",
                table: "SocieteAgences",
                type: "varchar(15)",
                unicode: false,
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_SocieteAgences_Collaborateurs_CollaborateurId",
                table: "SocieteAgences",
                column: "CollaborateurId",
                principalTable: "Collaborateurs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocieteAgences_Collaborateurs_CollaborateurId",
                table: "SocieteAgences");

            migrationBuilder.DropColumn(
                name: "ResponsableEmail",
                table: "SocieteAgences");

            migrationBuilder.DropColumn(
                name: "ResponsableTel",
                table: "SocieteAgences");

            migrationBuilder.RenameColumn(
                name: "ResponsableName",
                table: "SocieteAgences",
                newName: "CollaborateurName");

            migrationBuilder.AlterColumn<int>(
                name: "CollaborateurId",
                table: "SocieteAgences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SocieteAgences_Collaborateurs",
                table: "SocieteAgences",
                column: "CollaborateurId",
                principalTable: "Collaborateurs",
                principalColumn: "Id");
        }
    }
}
