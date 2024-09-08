using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samples.MT.Common.Data.PlatformDb.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class OptimisticConcurrencyFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "PlatformDb",
                table: "Tenants",
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
                schema: "PlatformDb",
                table: "Tenants");
        }
    }
}
