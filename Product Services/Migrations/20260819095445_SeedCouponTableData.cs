using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product_Services.Migrations
{
    /// <inheritdoc />
    public partial class SeedCouponTableData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "CouponCode" },
                values: new object[] { 1, "123A" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1);
        }
    }
}
