using System;

namespace CustomerShoppingApp.Models
{
    public class BankDetails
    {
        public string bankName { get; set; }
        public string accountNumber { get; set; }
        public string sortCode { get; set; }
        public DateTime expiryDate { get; set; }
    }
}
