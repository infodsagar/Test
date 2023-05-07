using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWebApp.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobDescs_Applications_ApplicationId",
                table: "JobDescs");

            migrationBuilder.DropIndex(
                name: "IX_JobDescs_ApplicationId",
                table: "JobDescs");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationId",
                table: "JobDescs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_JobDescs_ApplicationId",
                table: "JobDescs",
                column: "ApplicationId",
                unique: true,
                filter: "[ApplicationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_JobDescs_Applications_ApplicationId",
                table: "JobDescs",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobDescs_Applications_ApplicationId",
                table: "JobDescs");

            migrationBuilder.DropIndex(
                name: "IX_JobDescs_ApplicationId",
                table: "JobDescs");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationId",
                table: "JobDescs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobDescs_ApplicationId",
                table: "JobDescs",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobDescs_Applications_ApplicationId",
                table: "JobDescs",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
