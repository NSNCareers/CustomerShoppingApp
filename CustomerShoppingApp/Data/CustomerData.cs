using System;
using System.Collections.Generic;
using CustomerShoppingApp.Models;

namespace CustomerShoppingApp.Data
{
    public class CustomerData : ICustomerData
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
                firstName = "Jacob",
                address = new Address{

                    street = "Lonkuam Street",
                    houseNumber = 21,
                    postCode = "CV66 7HG",
                    country = "USA"
                },
                bankDetail = new BankDetail
                {
                    bankName = "Coventry Building Soceity",
                    accountNumber = 12338776353,
                    sortCode = 1234,
                    expiryDate = "09/24"

                },
                shoppingCart = new ShoppingCart
                {
                    shoppingCartName = "House Items",
                    item = new Item
                    {
                        cloth = new Cloth
                        {
                            price = 34.5,
                            size = 22,
                            brand = "Hugo Boss",
                            clothType = "Jeans"
                        },
                        shoe = new Shoe
                        {
                            price = 234,
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
