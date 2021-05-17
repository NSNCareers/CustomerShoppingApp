using System;
using CustomerShoppingApp.Models;

namespace CustomerShoppingApp.Data
{
    public interface ICustomerData
    {
        Customer InitializeCustomer();
    }
}
