using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataPatrolTask.Migrations
{
    /// <inheritdoc />
    public partial class SecondDataPortalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyAssignment_Groups_GroupId",
                table: "PolicyAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyAssignment_Policies_PolicyId",
                table: "PolicyAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_RequestedBy",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroupMembership_Groups_GroupId",
                table: "UserGroupMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroupMembership_Users_UserId",
                table: "UserGroupMembership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroupMembership",
                table: "UserGroupMembership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestedBy",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PolicyAssignment",
                table: "PolicyAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Policies",
                table: "Policies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserInfos");

            migrationBuilder.RenameTable(
                name: "UserGroupMembership",
                newName: "UserGroupsMembership");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "UserRequests");

            migrationBuilder.RenameTable(
                name: "PolicyAssignment",
                newName: "PolicyAssignments");

            migrationBuilder.RenameTable(
                name: "Policies",
                newName: "PolicyTables");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "UserGroups");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroupMembership_GroupId",
                table: "UserGroupsMembership",
                newName: "IX_UserGroupsMembership_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_PolicyAssignment_GroupId",
                table: "PolicyAssignments",
                newName: "IX_PolicyAssignments_GroupId");

            migrationBuilder.AlterColumn<string>(
                name: "RequestedBy",
                table: "UserRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "RequestedUserUserId",
                table: "UserRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfos",
                table: "UserInfos",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroupsMembership",
                table: "UserGroupsMembership",
                columns: new[] { "UserId", "GroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRequests",
                table: "UserRequests",
                column: "RequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PolicyAssignments",
                table: "PolicyAssignments",
                columns: new[] { "PolicyId", "GroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PolicyTables",
                table: "PolicyTables",
                column: "PolicyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequests_RequestedUserUserId",
                table: "UserRequests",
                column: "RequestedUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyAssignments_PolicyTables_PolicyId",
                table: "PolicyAssignments",
                column: "PolicyId",
                principalTable: "PolicyTables",
                principalColumn: "PolicyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyAssignments_UserGroups_GroupId",
                table: "PolicyAssignments",
                column: "GroupId",
                principalTable: "UserGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroupsMembership_UserGroups_GroupId",
                table: "UserGroupsMembership",
                column: "GroupId",
                principalTable: "UserGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroupsMembership_UserInfos_UserId",
                table: "UserGroupsMembership",
                column: "UserId",
                principalTable: "UserInfos",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequests_UserInfos_RequestedUserUserId",
                table: "UserRequests",
                column: "RequestedUserUserId",
                principalTable: "UserInfos",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyAssignments_PolicyTables_PolicyId",
                table: "PolicyAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyAssignments_UserGroups_GroupId",
                table: "PolicyAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroupsMembership_UserGroups_GroupId",
                table: "UserGroupsMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroupsMembership_UserInfos_UserId",
                table: "UserGroupsMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRequests_UserInfos_RequestedUserUserId",
                table: "UserRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRequests",
                table: "UserRequests");

            migrationBuilder.DropIndex(
                name: "IX_UserRequests_RequestedUserUserId",
                table: "UserRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfos",
                table: "UserInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroupsMembership",
                table: "UserGroupsMembership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PolicyTables",
                table: "PolicyTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PolicyAssignments",
                table: "PolicyAssignments");

            migrationBuilder.DropColumn(
                name: "RequestedUserUserId",
                table: "UserRequests");

            migrationBuilder.RenameTable(
                name: "UserRequests",
                newName: "Requests");

            migrationBuilder.RenameTable(
                name: "UserInfos",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UserGroupsMembership",
                newName: "UserGroupMembership");

            migrationBuilder.RenameTable(
                name: "UserGroups",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "PolicyTables",
                newName: "Policies");

            migrationBuilder.RenameTable(
                name: "PolicyAssignments",
                newName: "PolicyAssignment");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroupsMembership_GroupId",
                table: "UserGroupMembership",
                newName: "IX_UserGroupMembership_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_PolicyAssignments_GroupId",
                table: "PolicyAssignment",
                newName: "IX_PolicyAssignment_GroupId");

            migrationBuilder.AlterColumn<string>(
                name: "RequestedBy",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "RequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroupMembership",
                table: "UserGroupMembership",
                columns: new[] { "UserId", "GroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Policies",
                table: "Policies",
                column: "PolicyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PolicyAssignment",
                table: "PolicyAssignment",
                columns: new[] { "PolicyId", "GroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestedBy",
                table: "Requests",
                column: "RequestedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyAssignment_Groups_GroupId",
                table: "PolicyAssignment",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyAssignment_Policies_PolicyId",
                table: "PolicyAssignment",
                column: "PolicyId",
                principalTable: "Policies",
                principalColumn: "PolicyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_RequestedBy",
                table: "Requests",
                column: "RequestedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroupMembership_Groups_GroupId",
                table: "UserGroupMembership",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroupMembership_Users_UserId",
                table: "UserGroupMembership",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
