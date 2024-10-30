using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiFeed.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Db_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedStocks");

            migrationBuilder.AddColumn<double>(
                name: "Stock",
                table: "Feeds",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Feeds");

            migrationBuilder.CreateTable(
                name: "FeedStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedStocks_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedStocks_FeedId",
                table: "FeedStocks",
                column: "FeedId",
                unique: true);
        }
    }
}
