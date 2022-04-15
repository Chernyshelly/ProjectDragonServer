namespace Infrastructure.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class PlayersConfigured : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonalKey",
                table: "Players",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Players",
                newName: "RefreshToken");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Players",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "Players",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Players",
                newName: "PersonalKey");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "Players",
                newName: "FullName");
        }
    }
}
