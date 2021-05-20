using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("Customer")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string street { get; set; }
        [Required]
        public int houseNumber { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string postCode { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string country { get; set; }
    }
}
