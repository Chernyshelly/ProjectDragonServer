namespace Infrastructure.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class HighScoreToInt2ndPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HighScoreInt",
                table: "Players",
                newName: "HighScore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HighScore",
                table: "Players",
                newName: "HighScoreInt");
        }
    }
}
