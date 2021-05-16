using System;

namespace CustomerShoppingApp.Models
{
    public class BankDetail
    {
        public string bankName { get; set; }
        public long accountNumber { get; set; }
        public int sortCode { get; set; }
        public DateTime expiryDate { get; set; }
    }
}
