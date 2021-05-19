using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerShoppingApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.EnsureSchema(
                name: "Basket");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(3)", nullable: false),
                    firstName = table.Column<string>(type: "varchar(20)", nullable: false),
                    gender = table.Column<string>(type: "varchar(20)", nullable: false),
                    age = table.Column<string>(type: "varchar(3)", nullable: false),
                    email = table.Column<string>(type: "varchar(20)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    street = table.Column<string>(type: "varchar(20)", nullable: false),
                    houseNumber = table.Column<int>(type: "int", nullable: false),
                    postCode = table.Column<string>(type: "varchar(20)", nullable: false),
                    country = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                    table.ForeignKey(
                        name: "FK_Address_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Users",
                        principalTable: "Customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    bankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    sortCode = table.Column<string>(type: "varchar(20)", nullable: false),
                    expiryDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_BankDetails_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Users",
                        principalTable: "Customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                schema: "Basket",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    shoppingCartName = table.Column<string>(type: "varchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Users",
                        principalTable: "Customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.id);
                    table.ForeignKey(
                        name: "FK_Item_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalSchema: "Basket",
                        principalTable: "ShoppingCart",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cloth",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    size = table.Column<float>(type: "real", nullable: false),
                    brand = table.Column<string>(type: "varchar(200)", nullable: true),
                    clothType = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cloth", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cloth_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Furniture",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    furnitureName = table.Column<string>(type: "varchar(20)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    colour = table.Column<string>(type: "varchar(20)", nullable: false),
                    material = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furniture", x => x.id);
                    table.ForeignKey(
                        name: "FK_Furniture_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Garden",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    plantName = table.Column<string>(type: "varchar(20)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garden", x => x.id);
                    table.ForeignKey(
                        name: "FK_Garden_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shoe",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    size = table.Column<float>(type: "real", nullable: false),
                    brand = table.Column<string>(type: "varchar(20)", nullable: true),
                    colour = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoe", x => x.id);
                    table.ForeignKey(
                        name: "FK_Shoe_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                table: "Address",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_CustomerId",
                table: "BankDetails",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cloth_ItemId",
                table: "Cloth",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Furniture_ItemId",
                table: "Furniture",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Garden_ItemId",
                table: "Garden",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_ShoppingCartId",
                table: "Item",
                column: "ShoppingCartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_ItemId",
                table: "Shoe",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CustomerId",
                schema: "Basket",
                table: "ShoppingCart",
                column: "CustomerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "Cloth");

            migrationBuilder.DropTable(
                name: "Furniture");

            migrationBuilder.DropTable(
                name: "Garden");

            migrationBuilder.DropTable(
                name: "Shoe");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ShoppingCart",
                schema: "Basket");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Users");
        }
    }
}
