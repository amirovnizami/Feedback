using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedbackSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class file_upload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Comments");
        }
    }
}
