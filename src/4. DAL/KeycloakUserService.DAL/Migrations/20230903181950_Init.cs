using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeycloakUserService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeycloakEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventType = table.Column<byte>(type: "smallint", nullable: false),
                    OccurredAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeycloakEvents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeycloakEvents_OccurredAt",
                table: "KeycloakEvents",
                column: "OccurredAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeycloakEvents");
        }
    }
}
