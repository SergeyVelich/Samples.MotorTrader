using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samples.MT.Common.Data.PlatformDb.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AuditFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "PlatformDb",
                table: "Tenants",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "PlatformDb",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                schema: "PlatformDb",
                table: "Tenants",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                schema: "PlatformDb",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "PlatformDb",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "PlatformDb",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                schema: "PlatformDb",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "PlatformDb",
                table: "Tenants");
        }
    }
}
