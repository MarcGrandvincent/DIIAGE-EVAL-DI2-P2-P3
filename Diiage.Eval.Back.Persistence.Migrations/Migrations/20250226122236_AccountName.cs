using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diiage.Eval.Back.Persistence.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AccountName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                schema: "backoffice-core",
                table: "Passwords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
                schema: "backoffice-core",
                table: "Passwords");
        }
    }
}
