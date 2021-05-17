using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("Garden")]
    public class Garden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Column(TypeName = "varchar(10)")]
        [Required]
        public string plantName { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal price { get; set; }
        [Required]
        public float weight { get; set; }
    }
}
