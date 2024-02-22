using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chat_app.DataAccess.Migrations
{
    public partial class _AddForeignKeyInUSerMessageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "UserMessages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "UserMessages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_ReceiverId",
                table: "UserMessages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_SenderId",
                table: "UserMessages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_AspNetUsers_ReceiverId",
                table: "UserMessages",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_AspNetUsers_SenderId",
                table: "UserMessages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_AspNetUsers_ReceiverId",
                table: "UserMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_AspNetUsers_SenderId",
                table: "UserMessages");

            migrationBuilder.DropIndex(
                name: "IX_UserMessages_ReceiverId",
                table: "UserMessages");

            migrationBuilder.DropIndex(
                name: "IX_UserMessages_SenderId",
                table: "UserMessages");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "UserMessages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "UserMessages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
