using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerMonitor.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    ResponseTimeMs = table.Column<int>(type: "int", nullable: false),
                    ServerLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastChecked = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Targets",
                columns: new[] { "Id", "Category", "IsOnline", "LastChecked", "Name", "ResponseTimeMs", "ServerLocation", "Url" },
                values: new object[,]
                {
                    { 1, "Social", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YouTube", 0, null, "https://www.youtube.com" },
                    { 2, "Social", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Facebook", 0, null, "https://www.facebook.com" },
                    { 3, "Social", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "X", 0, null, "https://x.com" },
                    { 4, "Cloud", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AWS", 0, null, "https://aws.amazon.com" },
                    { 5, "Cloud", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azure", 0, null, "https://azure.microsoft.com" },
                    { 6, "Cloud", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cloudflare", 0, null, "https://www.cloudflare.com" },
                    { 7, "Government", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gov.pl", 0, null, "https://www.gov.pl" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Targets");
        }
    }
}
