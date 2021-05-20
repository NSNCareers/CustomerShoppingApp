using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("Furniture")]
    public class Furniture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("Item")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string furnitureName { get; set; }
        [Required]
        public double price { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string colour { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string material { get; set; }
    }
}
