using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VigilanceClearance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserProfile",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserProfile",
                table: "AspNetUsers");
        }
    }
}
