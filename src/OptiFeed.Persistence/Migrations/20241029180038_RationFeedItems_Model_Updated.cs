﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiFeed.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RationFeedItems_Model_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalCost",
                table: "RationDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "RationDetails");
        }
    }
}
