namespace CustomerShoppingApp.Models
{
    public class Items
    {
        public int id { get; set; }
        public int ShoppingCartId { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public float size { get; set; }
        public float weight { get; set; }
        public string brand { get; set; }
    }
}
