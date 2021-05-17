using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("Shoe")]
    public class Shoe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal price { get; set; }
        public float size { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string brand { get; set; }
        [Column(TypeName = "varchar(6)")]
        [Required]
        public string colour { get; set; }
    }
}
