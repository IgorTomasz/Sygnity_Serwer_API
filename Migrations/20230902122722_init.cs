using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CountNextTaskDate.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    count = table.Column<int>(type: "int", nullable: false),
                    currentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    firstOccurrence = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastOccurrence = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nextOccurrence = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");
        }
    }
}
