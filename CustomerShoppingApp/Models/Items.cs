using System.Collections.Generic;

namespace CustomerShoppingApp.Models
{
    public class Items
    {
        public int id { get; set; }
        public int ShoppingCartId { get; set; }
        public Shoes shoes { get; set; }
        public Garden garden { get; set; }
        public Furniture furniture { get; set; }
        public Clothes clothes { get; set; }
    }
}
