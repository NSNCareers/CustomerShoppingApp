using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string street { get; set; }
        [Required]
        public int houseNumber { get; set; }
        [Column(TypeName = "varchar(8)")]
        [Required]
        public string postCode { get; set; }
        [Column(TypeName = "varchar(12)")]
        [Required]
        public string country { get; set; }
    }
}
