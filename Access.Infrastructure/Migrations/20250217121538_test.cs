using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Access.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Societe",
                keyColumn: "Id",
                keyValue: 1,
                column: "RaisonSocial",
                value: "bb");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Societe",
                keyColumn: "Id",
                keyValue: 1,
                column: "RaisonSocial",
                value: "aa");
        }
    }
}
