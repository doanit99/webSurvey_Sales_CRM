using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSurvey_Sales_CRM.Migrations
{
    /// <inheritdoc />
    public partial class Add_TypeUser_in_table_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeUser",
                table: "Users",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeUser",
                table: "Users");
        }
    }
}
