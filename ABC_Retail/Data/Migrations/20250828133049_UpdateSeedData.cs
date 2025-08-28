using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABC_Retail.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://retailstoreabc.blob.core.windows.net/productimage/CoteizAirMax95.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://retailstoreabc.blob.core.windows.net/productimage/NikeShoX.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://retailstoreabc.blob.core.windows.net/productimage/NikeAirForce1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://retailstoreabc.blob.core.windows.net/productimage/NewBalance1000.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://retailstoreabc.blob.core.windows.net/productimage/Coteiz%20Air%20Max%2095.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://retailstoreabc.blob.core.windows.net/productimage/Nike%20ShoX.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://retailstoreabc.blob.core.windows.net/productimage/Nike%20Air%20Force%201.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://retailstoreabc.blob.core.windows.net/productimage/New%20Balance%201000.jpg");
        }
    }
}
