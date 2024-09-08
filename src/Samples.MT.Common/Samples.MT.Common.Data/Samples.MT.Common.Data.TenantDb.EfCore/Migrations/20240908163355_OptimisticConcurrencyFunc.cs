using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samples.MT.Common.Data.TenantDb.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class OptimisticConcurrencyFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "TenantDb",
                table: "Users",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "TenantDb",
                table: "UserRoles",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "TenantDb",
                table: "Tenants",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "TenantDb",
                table: "Roles",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                schema: "TenantDb",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "TenantDb",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "TenantDb",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "TenantDb",
                table: "Roles");
        }
    }
}
