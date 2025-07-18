using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataPatrolTask.Migrations
{
    /// <inheritdoc />
    public partial class RequestCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRequests_UserInfos_RequestedUserUserId",
                table: "UserRequests");

            migrationBuilder.AlterColumn<string>(
                name: "RequestedUserUserId",
                table: "UserRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequests_UserInfos_RequestedUserUserId",
                table: "UserRequests",
                column: "RequestedUserUserId",
                principalTable: "UserInfos",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRequests_UserInfos_RequestedUserUserId",
                table: "UserRequests");

            migrationBuilder.AlterColumn<string>(
                name: "RequestedUserUserId",
                table: "UserRequests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRequests_UserInfos_RequestedUserUserId",
                table: "UserRequests",
                column: "RequestedUserUserId",
                principalTable: "UserInfos",
                principalColumn: "UserId");
        }
    }
}
