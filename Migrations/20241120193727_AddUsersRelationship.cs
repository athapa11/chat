using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Message",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Chat",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UserId",
                table: "Chat",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_User_UserId",
                table: "Chat",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_UserId",
                table: "Message",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_User_UserId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_UserId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_UserId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Chat_UserId",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Chat");
        }
    }
}
