using System.Collections.Generic;

namespace CustomerShoppingApp.Models
{
    public class ShoppingCart
    {
        public int id { get; set; }
        public int CustomerId { get; set; }
        public string shoppingCartName { get; set; }
        public Items item { get; set; }
    }
}
