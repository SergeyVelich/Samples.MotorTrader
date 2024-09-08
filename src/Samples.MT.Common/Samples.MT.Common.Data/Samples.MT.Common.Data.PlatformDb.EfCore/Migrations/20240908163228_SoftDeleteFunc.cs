using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samples.MT.Common.Data.PlatformDb.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeleteFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "PlatformDb",
                table: "Tenants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "PlatformDb",
                table: "Tenants");
        }
    }
}
