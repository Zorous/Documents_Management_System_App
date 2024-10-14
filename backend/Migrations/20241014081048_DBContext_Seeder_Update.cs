using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class DBContext_Seeder_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Users_CreatorUserId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_Department_User_Departments_DepartmentId",
                table: "Tenant_Department_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_Department_User_Tenants_TenantId",
                table: "Tenant_Department_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_Department_User_Users_UserId",
                table: "Tenant_Department_User");

            migrationBuilder.DropIndex(
                name: "IX_Documents_CreatorUserId",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenant_Department_User",
                table: "Tenant_Department_User");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Documents");

            migrationBuilder.RenameTable(
                name: "Tenant_Department_User",
                newName: "Tenant_Department_Users");

            migrationBuilder.RenameIndex(
                name: "IX_Tenant_Department_User_UserId",
                table: "Tenant_Department_Users",
                newName: "IX_Tenant_Department_Users_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tenant_Department_User_TenantId",
                table: "Tenant_Department_Users",
                newName: "IX_Tenant_Department_Users_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Tenant_Department_User_DepartmentId",
                table: "Tenant_Department_Users",
                newName: "IX_Tenant_Department_Users_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenant_Department_Users",
                table: "Tenant_Department_Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CreatedBy",
                table: "Documents",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Users_CreatedBy",
                table: "Documents",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_Department_Users_Departments_DepartmentId",
                table: "Tenant_Department_Users",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_Department_Users_Tenants_TenantId",
                table: "Tenant_Department_Users",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_Department_Users_Users_UserId",
                table: "Tenant_Department_Users",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Users_CreatedBy",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_Department_Users_Departments_DepartmentId",
                table: "Tenant_Department_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_Department_Users_Tenants_TenantId",
                table: "Tenant_Department_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_Department_Users_Users_UserId",
                table: "Tenant_Department_Users");

            migrationBuilder.DropIndex(
                name: "IX_Documents_CreatedBy",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenant_Department_Users",
                table: "Tenant_Department_Users");

            migrationBuilder.RenameTable(
                name: "Tenant_Department_Users",
                newName: "Tenant_Department_User");

            migrationBuilder.RenameIndex(
                name: "IX_Tenant_Department_Users_UserId",
                table: "Tenant_Department_User",
                newName: "IX_Tenant_Department_User_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tenant_Department_Users_TenantId",
                table: "Tenant_Department_User",
                newName: "IX_Tenant_Department_User_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Tenant_Department_Users_DepartmentId",
                table: "Tenant_Department_User",
                newName: "IX_Tenant_Department_User_DepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "CreatorUserId",
                table: "Documents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenant_Department_User",
                table: "Tenant_Department_User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CreatorUserId",
                table: "Documents",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Users_CreatorUserId",
                table: "Documents",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_Department_User_Departments_DepartmentId",
                table: "Tenant_Department_User",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_Department_User_Tenants_TenantId",
                table: "Tenant_Department_User",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_Department_User_Users_UserId",
                table: "Tenant_Department_User",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
