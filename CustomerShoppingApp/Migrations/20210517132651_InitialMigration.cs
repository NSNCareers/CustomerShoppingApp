using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerShoppingApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.EnsureSchema(
                name: "Basket");

            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    bankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountNumber = table.Column<string>(type: "varchar(8)", nullable: false),
                    sortCode = table.Column<string>(type: "varchar(6)", nullable: false),
                    expiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cloth",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    size = table.Column<float>(type: "real", nullable: false),
                    brand = table.Column<string>(type: "varchar(10)", nullable: true),
                    clothType = table.Column<string>(type: "varchar(12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cloth", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Furniture",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    furnitureName = table.Column<string>(type: "varchar(12)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    colour = table.Column<string>(type: "varchar(6)", nullable: false),
                    material = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furniture", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Garden",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    plantName = table.Column<string>(type: "varchar(10)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garden", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Shoe",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    size = table.Column<float>(type: "real", nullable: false),
                    brand = table.Column<string>(type: "varchar(10)", nullable: true),
                    colour = table.Column<string>(type: "varchar(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoe", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(3)", nullable: false),
                    firstName = table.Column<string>(type: "varchar(15)", nullable: false),
                    gender = table.Column<string>(type: "varchar(6)", nullable: false),
                    age = table.Column<string>(type: "varchar(3)", nullable: false),
                    email = table.Column<string>(type: "varchar(10)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    bankDetailid = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                    table.ForeignKey(
                        name: "FK_Customer_BankDetails_bankDetailid",
                        column: x => x.bankDetailid,
                        principalTable: "BankDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    street = table.Column<string>(type: "varchar(20)", nullable: false),
                    houseNumber = table.Column<int>(type: "int", nullable: false),
                    postCode = table.Column<string>(type: "varchar(8)", nullable: false),
                    country = table.Column<string>(type: "varchar(12)", nullable: false),
                    Customerid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                    table.ForeignKey(
                        name: "FK_Address_Customer_Customerid",
                        column: x => x.Customerid,
                        principalSchema: "Users",
                        principalTable: "Customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                schema: "Basket",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
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
                    id = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    shoeid = table.Column<int>(type: "int", nullable: true),
                    gardenid = table.Column<int>(type: "int", nullable: true),
                    furnitureid = table.Column<int>(type: "int", nullable: true),
                    clothid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.id);
                    table.ForeignKey(
                        name: "FK_Item_Cloth_clothid",
                        column: x => x.clothid,
                        principalTable: "Cloth",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Furniture_furnitureid",
                        column: x => x.furnitureid,
                        principalTable: "Furniture",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Garden_gardenid",
                        column: x => x.gardenid,
                        principalTable: "Garden",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Shoe_shoeid",
                        column: x => x.shoeid,
                        principalTable: "Shoe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalSchema: "Basket",
                        principalTable: "ShoppingCart",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Customerid",
                table: "Address",
                column: "Customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_bankDetailid",
                schema: "Users",
                table: "Customer",
                column: "bankDetailid");

            migrationBuilder.CreateIndex(
                name: "IX_Item_clothid",
                table: "Item",
                column: "clothid");

            migrationBuilder.CreateIndex(
                name: "IX_Item_furnitureid",
                table: "Item",
                column: "furnitureid");

            migrationBuilder.CreateIndex(
                name: "IX_Item_gardenid",
                table: "Item",
                column: "gardenid");

            migrationBuilder.CreateIndex(
                name: "IX_Item_shoeid",
                table: "Item",
                column: "shoeid");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ShoppingCartId",
                table: "Item",
                column: "ShoppingCartId",
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
                name: "Item");

            migrationBuilder.DropTable(
                name: "Cloth");

            migrationBuilder.DropTable(
                name: "Furniture");

            migrationBuilder.DropTable(
                name: "Garden");

            migrationBuilder.DropTable(
                name: "Shoe");

            migrationBuilder.DropTable(
                name: "ShoppingCart",
                schema: "Basket");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "BankDetails");
        }
    }
}
