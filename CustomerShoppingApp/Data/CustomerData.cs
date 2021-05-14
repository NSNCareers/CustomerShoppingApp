using System;
using System.Collections.Generic;
using CustomerShoppingApp.Models;

namespace CustomerShoppingApp.Data
{
    public class CustomerData : ICustomer
    {
        public CustomerData()
        {
        }

        public Customer InitializeCustomer()
        {
            var customer = new Customer
            {
                title = "Mr",
                age = 34,
                gender = "Male",
                name = "Jacob",
                address = new List<Address>
                {
                    new Address
                    {
                        street = "Lonkuam Street",
                        houseNumber = 21,
                        postCode = "CV66 7HG",
                        country = "USA"
                    }
                },
                bankDetails = new BankDetails
                {
                    bankName = "Coventry Building Soceity",
                    accountNumber = 12338776353,
                    sortCode = 1234,
                    expiryDate = DateTime.Now

                },
                shoppingCart = new ShoppingCart
                {
                    shoppingCartName = "House Items",
                    item = new Items
                    {
                        clothes = new Clothes
                        {
                            price = 34.5,
                            size = 22,
                            brand = "Hugo Boss",
                            clothType = "Jeans"
                        },
                        shoes = new Shoes
                        {
                            price = 234.2,
                            size = 65,
                            brand = "Gucci",
                            colour = "Red"
                        },
                        furniture = new Furniture
                        {
                            price = 998,
                            furnitureName = "Stool",
                            colour = "White",
                            material = "Leather"
                        },
                        garden = new Garden
                        {
                            plantName = "Flowers",
                            price = 8766,
                            weight = 99
                        }
                    }
                }
            };
            return customer;
        }
    }
}
