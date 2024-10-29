using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiFeed.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Updated_AppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedStock_Feeds_FeedId",
                table: "FeedStock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedStock",
                table: "FeedStock");

            migrationBuilder.RenameTable(
                name: "FeedStock",
                newName: "FeedStocks");

            migrationBuilder.RenameIndex(
                name: "IX_FeedStock_FeedId",
                table: "FeedStocks",
                newName: "IX_FeedStocks_FeedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedStocks",
                table: "FeedStocks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveWeight = table.Column<double>(type: "float", nullable: false),
                    DailyMilkYield = table.Column<double>(type: "float", nullable: false),
                    MilkFat = table.Column<double>(type: "float", nullable: false),
                    MilkProtein = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rations_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RationDetails_Rations_RationId",
                        column: x => x.RationId,
                        principalTable: "Rations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RationFeedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RationDetailId = table.Column<int>(type: "int", nullable: false),
                    FeedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerKg = table.Column<double>(type: "float", nullable: false),
                    UsagePercentage = table.Column<double>(type: "float", nullable: false),
                    UsageAmountKg = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RationFeedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RationFeedItems_RationDetails_RationDetailId",
                        column: x => x.RationDetailId,
                        principalTable: "RationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RationDetails_RationId",
                table: "RationDetails",
                column: "RationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RationFeedItems_RationDetailId",
                table: "RationFeedItems",
                column: "RationDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Rations_AnimalId",
                table: "Rations",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedStocks_Feeds_FeedId",
                table: "FeedStocks",
                column: "FeedId",
                principalTable: "Feeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedStocks_Feeds_FeedId",
                table: "FeedStocks");

            migrationBuilder.DropTable(
                name: "RationFeedItems");

            migrationBuilder.DropTable(
                name: "RationDetails");

            migrationBuilder.DropTable(
                name: "Rations");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedStocks",
                table: "FeedStocks");

            migrationBuilder.RenameTable(
                name: "FeedStocks",
                newName: "FeedStock");

            migrationBuilder.RenameIndex(
                name: "IX_FeedStocks_FeedId",
                table: "FeedStock",
                newName: "IX_FeedStock_FeedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedStock",
                table: "FeedStock",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedStock_Feeds_FeedId",
                table: "FeedStock",
                column: "FeedId",
                principalTable: "Feeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
