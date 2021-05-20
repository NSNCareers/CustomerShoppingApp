using CustomerShoppingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
namespace CustomerShoppingApp.Data
{
    public static class ModelBuilderExtension
    {
        public static void SeedAddressData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData
                (
                new Address
                {
                    id = 1,
                    CustomerId = 1,
                    street = "NSNCareers Street",
                    houseNumber = 22,
                    postCode = "CV55 7KJ",
                    country = "UK"
                }
                );
        }

        public static void SeedBankDetailData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankDetail>().HasData
                (
                new BankDetail
                {
                    id = 1,
                    CustomerId = 1,
                    bankName = "Nat-West Bank",
                    accountNumber = 1234567,
                    sortCode = 23234,
                    expiryDate = "04/25"
                }
                );
        }

        public static void SeedClothData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cloth>().HasData
                (
                new Cloth
                {
                    id = 1,
                    ItemId = 1,
                    brand = "Gucci",
                    size = 23,
                    price = 234,
                    clothType = "Shirt"
                }
                );
        }

        public static void SeedCustomerData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData
                (
                new Customer
                {
                    id = 1,
                    title = "Mr",
                    gender = "Male",
                    firstName = "Morales",
                    email = "Morales@gmail.com",
                    age = 45,
                    Created = DateTime.Now,
                    IsActive = true,
                }
                );
        }

        public static void SeedFurnitureData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Furniture>().HasData
                (
                new Furniture
                {
                    id = 1,
                    ItemId = 1,
                    furnitureName = "Sofa",
                    price = 2100,
                    material = "Velvet",
                    colour = "Blue"
                }
                );
        }

        public static void SeedGardenData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Garden>().HasData
                (
                new Garden
                {
                    id = 1,
                    ItemId = 1,
                    plantName = "Flowers",
                    price = 232,
                    weight = 233
                }
                );
        }

        public static void SeedBItemData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData
                (
                new Item
                {
                    id = 1,
                    ShoppingCartId = 1
                }
                );
        }

        public static void SeedShoeData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shoe>().HasData
                (
                new Shoe
                {
                    id = 1,
                    ItemId = 1,
                    brand = "Gucci",
                    colour = "Green",
                    price = 123,
                    size = 234
                }
                );
        }

        public static void SeedShoppingCartData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCart>().HasData
                (
                new ShoppingCart
                {
                    id = 1,
                    CustomerId = 1,
                    shoppingCartName = "Daily Shopping"
                }
                );
        }
    }
}
