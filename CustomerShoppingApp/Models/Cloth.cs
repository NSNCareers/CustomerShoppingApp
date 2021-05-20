using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("Cloth")]
    public class Cloth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("Item")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public float size { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string brand { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string clothType { get; set; }
    }
}
