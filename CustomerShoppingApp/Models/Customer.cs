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
        // So that entity framework will populate address when getting shoppingcart from DB
        public virtual List<Address> address { get; set; }
        public BankDetails bankDetails{ get; set; }
        public ShoppingCart shoppingCart { get; set; }
    }
}
