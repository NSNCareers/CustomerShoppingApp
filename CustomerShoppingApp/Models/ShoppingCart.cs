using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("ShoppingCart",Schema ="Basket")]
    public class ShoppingCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("Customer")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Column(TypeName = "varchar(12)")]
        [Required]
        public string shoppingCartName { get; set; }
        [Required]
        public virtual Item item { get; set; }
    }
}
