using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameCore.Migrations
{
    /// <inheritdoc />
    public partial class RemovedIdFromUsernameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usernames",
                table: "Usernames");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Usernames");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Usernames",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                collation: "SQL_Latin1_General_CP1_CS_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldCollation: "SQL_Latin1_General_CP1_CS_AS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usernames",
                table: "Usernames",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usernames",
                table: "Usernames");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Usernames",
                type: "nvarchar(450)",
                nullable: true,
                collation: "SQL_Latin1_General_CP1_CS_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldCollation: "SQL_Latin1_General_CP1_CS_AS");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Usernames",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usernames",
                table: "Usernames",
                column: "Id");
        }
    }
}
