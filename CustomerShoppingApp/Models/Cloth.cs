using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("Cloth")]
    public class Cloth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public float size { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string brand { get; set; }
        [Column(TypeName = "varchar(12)")]
        public string clothType { get; set; }
    }
}
