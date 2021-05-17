using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("BankDetails")]
    public class BankDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string bankName { get; set; }
        [Column(TypeName = "varchar(8)")]
        [Required]
        public long accountNumber { get; set; }
        [Column(TypeName = "varchar(6)")]
        [Required]
        public int sortCode { get; set; }
        [Required]
        public string expiryDate { get; set; }
    }
}
