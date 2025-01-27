using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P_L_U_M_E_R_I_A.Migrations
{
    /// <inheritdoc />
    public partial class forkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductsCate_id",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductsCate_id",
                table: "Products");
        }
    }
}
