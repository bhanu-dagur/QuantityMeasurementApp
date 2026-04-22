using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HistoryService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurementHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InputValue1 = table.Column<double>(type: "float", nullable: false),
                    InputUnit1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InputValue2 = table.Column<double>(type: "float", nullable: true),
                    InputUnit2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultValue = table.Column<double>(type: "float", nullable: false),
                    ResultUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementHistory", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurementHistory");
        }
    }
}
