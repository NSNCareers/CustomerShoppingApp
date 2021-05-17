using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerShoppingApp.Models
{
    [Table("Customer",Schema ="Users")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Column(TypeName = "varchar(3)")]
        [Required]
        public string title { get; set; }
        [Column(TypeName = "varchar(15)")]
        [Required]
        [ConcurrencyCheck]
        public string firstName { get; set; }
        [Column(TypeName = "varchar(6)")]
        [Required]
        public string gender { get; set; }
        [Column(TypeName = "varchar(3)")]
        [Required]
        public int age { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string email { get; set; }
        public bool IsActive { get; set; }
        // So that entity framework will populate address when getting shoppingcart from DB
        [Required]
        public virtual List<Address> address { get; set; }
        [Required]
        public virtual BankDetail bankDetail{ get; set; }
        [Required]
        public virtual ShoppingCart shoppingCart { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
