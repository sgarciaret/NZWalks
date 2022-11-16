using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalksAPI.Migrations
{
    public partial class addingusers5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_RoleId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "Users_Roles");

            migrationBuilder.RenameColumn(
                name: "EmailAdress",
                table: "Users",
                newName: "EmailAddress");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "Users_Roles",
                newName: "IX_Users_Roles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users_Roles",
                table: "Users_Roles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Roles_UserId",
                table: "Users_Roles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_Roles_RoleId",
                table: "Users_Roles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_Users_UserId",
                table: "Users_Roles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_Roles_RoleId",
                table: "Users_Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_Users_UserId",
                table: "Users_Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users_Roles",
                table: "Users_Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_Roles_UserId",
                table: "Users_Roles");

            migrationBuilder.RenameTable(
                name: "Users_Roles",
                newName: "UserRoles");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Users",
                newName: "EmailAdress");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Roles_RoleId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
