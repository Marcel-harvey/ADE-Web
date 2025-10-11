using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADE_Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDbContextApps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appsBuilt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppGitHubUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appsBuilt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "appImprovement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Improvement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppsBuiltId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appImprovement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appImprovement_appsBuilt_AppsBuiltId",
                        column: x => x.AppsBuiltId,
                        principalTable: "appsBuilt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appImprovement_AppsBuiltId",
                table: "appImprovement",
                column: "AppsBuiltId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appImprovement");

            migrationBuilder.DropTable(
                name: "appsBuilt");
        }
    }
}
