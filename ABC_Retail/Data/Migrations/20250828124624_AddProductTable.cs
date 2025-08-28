using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ABC_Retail.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Sleek black sneakers with a layered design and visible Air Max cushioning, offering comfort and street-ready style.", "https://retailstoreabc.blob.core.windows.net/productimage/Coteiz%20Air%20Max%2095.png", "Nike Cortiez Air Max 95", 4400.00m },
                    { 2, "Crisp white athletic shoes featuring Nike’s Shox cushioning columns for responsive impact protection.", "https://retailstoreabc.blob.core.windows.net/productimage/Nike%20ShoX.png", "Nike ShoX TL", 3300.00m },
                    { 3, "Classic low-top silhouette with a clean white and grey colorway, iconic for its durable leather and versatile style.", "https://retailstoreabc.blob.core.windows.net/productimage/Nike%20Air%20Force%201.jpg", "Nike Air Force 1", 2400.00m },
                    { 4, "Retro-inspired running shoes with premium grey and silver tones, known for cushioning and timeless appeal.", "https://retailstoreabc.blob.core.windows.net/productimage/New%20Balance%201000.jpg", "New Balance 1000", 3400.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
