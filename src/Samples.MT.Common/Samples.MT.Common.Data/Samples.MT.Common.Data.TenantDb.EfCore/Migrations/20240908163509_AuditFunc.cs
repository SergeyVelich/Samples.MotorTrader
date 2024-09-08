using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samples.MT.Common.Data.TenantDb.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AuditFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "TenantDb",
                table: "Users",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "TenantDb",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                schema: "TenantDb",
                table: "Users",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "TenantDb",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "TenantDb",
                table: "UserRoles",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "TenantDb",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                schema: "TenantDb",
                table: "UserRoles",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "TenantDb",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "TenantDb",
                table: "Tenants",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "TenantDb",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                schema: "TenantDb",
                table: "Tenants",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "TenantDb",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "TenantDb",
                table: "Roles",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "TenantDb",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                schema: "TenantDb",
                table: "Roles",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "TenantDb",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "TenantDb",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "TenantDb",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                schema: "TenantDb",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "TenantDb",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "TenantDb",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "TenantDb",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                schema: "TenantDb",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "TenantDb",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "TenantDb",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "TenantDb",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                schema: "TenantDb",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "TenantDb",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "TenantDb",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "TenantDb",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                schema: "TenantDb",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "TenantDb",
                table: "Roles");
        }
    }
}
