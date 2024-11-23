using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashApi.Migrations
{
    /// <inheritdoc />
    public partial class addmessageedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Edited",
                table: "Message",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edited",
                table: "Message");
        }
    }
}
