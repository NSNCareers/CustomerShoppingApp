using System;
using CustomerShoppingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerShoppingApp.Context
{
    public class CustomerShoppingCartContext : DbContext
    {

        //This entity will be translated into data base tables
        //Virtual to prevent eager loading
        public virtual DbSet<ShoppingCart> ShoppingCarts{ get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<BankDetail> BankDetails { get; set; }
        public virtual DbSet<Cloth> Clothes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Furniture> Furnitures { get; set; }
        public virtual DbSet<Garden> Gardens { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Shoe> Shoes { get; set; }



        public CustomerShoppingCartContext(DbContextOptions<CustomerShoppingCartContext> options)
            :base(options)
        {
        }
    }
}
