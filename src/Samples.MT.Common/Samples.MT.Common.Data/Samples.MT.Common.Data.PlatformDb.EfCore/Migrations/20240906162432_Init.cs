using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samples.MT.Common.Data.PlatformDb.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PlatformDb");

            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "PlatformDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    SubdomainName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenantConfigStoreKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsMaster = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "PlatformDb");
        }
    }
}
