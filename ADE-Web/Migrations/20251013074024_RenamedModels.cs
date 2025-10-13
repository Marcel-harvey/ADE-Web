using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADE_Web.Migrations
{
    /// <inheritdoc />
    public partial class RenamedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_techStackModel",
                table: "techStackModel");

            migrationBuilder.RenameTable(
                name: "techStackModel",
                newName: "techStack");

            migrationBuilder.AddPrimaryKey(
                name: "PK_techStack",
                table: "techStack",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_techStack",
                table: "techStack");

            migrationBuilder.RenameTable(
                name: "techStack",
                newName: "techStackModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_techStackModel",
                table: "techStackModel",
                column: "Id");
        }
    }
}
