using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("Shoe")]
    public class Shoe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("Item")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal price { get; set; }
        public float size { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string brand { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string colour { get; set; }
    }
}
