using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product_Services.Migrations
{
    /// <inheritdoc />
    public partial class AddedDiscountAndMinAmountColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DiscountAmount",
                table: "Coupons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "MinAmount",
                table: "Coupons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1,
                columns: new[] { "DiscountAmount", "MinAmount" },
                values: new object[] { 0.0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "MinAmount",
                table: "Coupons");
        }
    }
}
