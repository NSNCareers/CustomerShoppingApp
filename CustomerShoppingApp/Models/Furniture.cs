using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("Furniture")]
    public class Furniture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Column(TypeName = "varchar(12)")]
        [Required]
        public string furnitureName { get; set; }
        [Required]
        public double price { get; set; }
        [Column(TypeName = "varchar(6)")]
        [Required]
        public string colour { get; set; }
        [Column(TypeName = "varchar(10)")]
        [Required]
        public string material { get; set; }
    }
}
