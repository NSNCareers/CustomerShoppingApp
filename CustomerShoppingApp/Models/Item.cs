using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("Item")]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [ForeignKey("ShoppingCart")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShoppingCartId { get; set; }
        [Required]
        public virtual Shoe shoe { get; set; }
        [Required]
        public virtual Garden garden { get; set; }
        [Required]
        public virtual Furniture furniture { get; set; }
        [Required]
        public virtual Cloth cloth { get; set; }
    }
}
