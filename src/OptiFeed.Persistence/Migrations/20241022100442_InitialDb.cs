using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiFeed.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DryMatter = table.Column<double>(type: "float", nullable: false),
                    EnergyContent = table.Column<double>(type: "float", nullable: false),
                    ProteinContent = table.Column<double>(type: "float", nullable: false),
                    NDFContent = table.Column<double>(type: "float", nullable: false),
                    ADFContent = table.Column<double>(type: "float", nullable: false),
                    CostPerKg = table.Column<double>(type: "float", nullable: false),
                    MaxUsage = table.Column<double>(type: "float", nullable: false),
                    MinUsage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeds", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feeds");
        }
    }
}
