using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomeetBackend.Migrations
{
    /// <inheritdoc />
    public partial class fixedPLS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Subscription_Subscribed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Subscription_PollFrequency = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbAdapter",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Columns = table.Column<string>(type: "TEXT", nullable: true),
                    ActiveColumns = table.Column<string>(type: "TEXT", nullable: true),
                    AdapterType = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false),
                    ApiUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ApiKey = table.Column<string>(type: "TEXT", nullable: true),
                    AccessToken = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbAdapter", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_DbAdapter_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbAdapter");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
