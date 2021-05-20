using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("Garden")]
    public class Garden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("Item")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string plantName { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal price { get; set; }
        [Required]
        public float weight { get; set; }
    }
}
