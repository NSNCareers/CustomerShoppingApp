using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("BankDetails")]
    public class BankDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("Customer")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string bankName { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public long accountNumber { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required]
        public int sortCode { get; set; }
        [Required]
        public string expiryDate { get; set; }
    }
}
