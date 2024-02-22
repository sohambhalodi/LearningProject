using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chat_app.DataAccess.Migrations
{
    public partial class _GroupAndUserToGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserToGroups_AspNetUsers_UserId",
                table: "UserToGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToGroups_Groups_GropId",
                table: "UserToGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserToGroups",
                table: "UserToGroups");

            migrationBuilder.RenameTable(
                name: "UserToGroups",
                newName: "UsersToGroups");

            migrationBuilder.RenameIndex(
                name: "IX_UserToGroups_UserId",
                table: "UsersToGroups",
                newName: "IX_UsersToGroups_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserToGroups_GropId",
                table: "UsersToGroups",
                newName: "IX_UsersToGroups_GropId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersToGroups",
                table: "UsersToGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersToGroups_AspNetUsers_UserId",
                table: "UsersToGroups",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersToGroups_Groups_GropId",
                table: "UsersToGroups",
                column: "GropId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersToGroups_AspNetUsers_UserId",
                table: "UsersToGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersToGroups_Groups_GropId",
                table: "UsersToGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersToGroups",
                table: "UsersToGroups");

            migrationBuilder.RenameTable(
                name: "UsersToGroups",
                newName: "UserToGroups");

            migrationBuilder.RenameIndex(
                name: "IX_UsersToGroups_UserId",
                table: "UserToGroups",
                newName: "IX_UserToGroups_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersToGroups_GropId",
                table: "UserToGroups",
                newName: "IX_UserToGroups_GropId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserToGroups",
                table: "UserToGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToGroups_AspNetUsers_UserId",
                table: "UserToGroups",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToGroups_Groups_GropId",
                table: "UserToGroups",
                column: "GropId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
