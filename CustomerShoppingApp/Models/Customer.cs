using System.Collections.Generic;

namespace CustomerShoppingApp.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public List<Address> address { get; set; }
        public BankDetails bankDetails{ get; set; }
        public ShoppingCart shoppingCart { get; set; }
    }
}
