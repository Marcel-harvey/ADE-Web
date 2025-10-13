using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADE_Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangedModelTitleName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogDescription",
                table: "blog",
                newName: "BlogContent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogContent",
                table: "blog",
                newName: "BlogDescription");
        }
    }
}
