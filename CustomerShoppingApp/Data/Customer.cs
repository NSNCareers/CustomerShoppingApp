using System;
using CustomerShoppingApp.Models;

namespace CustomerShoppingApp.Data
{
    public interface ICustomer
    {
        Customer InitializeCustomer();
    }
}
