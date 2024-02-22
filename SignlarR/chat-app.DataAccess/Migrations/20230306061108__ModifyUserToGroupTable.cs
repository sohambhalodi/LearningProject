using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chat_app.DataAccess.Migrations
{
    public partial class _ModifyUserToGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersToGroups_Groups_GropId",
                table: "UsersToGroups");

            migrationBuilder.RenameColumn(
                name: "GropId",
                table: "UsersToGroups",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersToGroups_GropId",
                table: "UsersToGroups",
                newName: "IX_UsersToGroups_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersToGroups_Groups_GroupId",
                table: "UsersToGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersToGroups_Groups_GroupId",
                table: "UsersToGroups");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "UsersToGroups",
                newName: "GropId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersToGroups_GroupId",
                table: "UsersToGroups",
                newName: "IX_UsersToGroups_GropId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersToGroups_Groups_GropId",
                table: "UsersToGroups",
                column: "GropId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
