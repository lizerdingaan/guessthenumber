using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameCore.Migrations
{
    /// <inheritdoc />
    public partial class UsernameType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameInstances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsernameId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RandomNumber = table.Column<int>(type: "int", nullable: false),
                    NumberOfTries = table.Column<int>(type: "int", nullable: false),
                    GameStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameInstances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usernames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usernames", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameInstances");

            migrationBuilder.DropTable(
                name: "Usernames");
        }
    }
}
