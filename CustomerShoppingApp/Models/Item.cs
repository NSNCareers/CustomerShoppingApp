using System.Collections.Generic;

namespace CustomerShoppingApp.Models
{
    public class Item
    {
        public int id { get; set; }
        public int ShoppingCartId { get; set; }
        public Shoe shoe { get; set; }
        public Garden garden { get; set; }
        public Furniture furniture { get; set; }
        public Cloth cloth { get; set; }
    }
}
