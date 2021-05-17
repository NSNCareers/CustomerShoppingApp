using CustomerShoppingApp.Context;
using CustomerShoppingApp.DAL;
using CustomerShoppingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerShoppingApp.DataContext
{
    public class CustomerShoppingCart : ICustomerShoppingCart
    {
        private readonly IDataBaseChanges _dataBaseChanges;
        private readonly CustomerShoppingCartContext _customerShoppingCartContext;

        public CustomerShoppingCart(IDataBaseChanges dataBaseChanges, CustomerShoppingCartContext customerShoppingCartContext)
        {
            _customerShoppingCartContext = customerShoppingCartContext;
            _dataBaseChanges = dataBaseChanges;
        }


        public async Task<IActionResult> CreateNewCustomer(Customer customer)
        {
            if (customer != null)
            {
                try
                {
                    await _dataBaseChanges.AddAsync(customer);
                    await _dataBaseChanges.CommitAsync();

                    return new CreatedResult("Successfully created customer", customer);
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult($"Unable to create Customer due to exception: {e.Message}");
                }
            }

            return new BadRequestObjectResult("Customer object cannot be null");
        }

        public async Task<IActionResult> DeletCustomer(Customer customer)
        {
            if (customer != null)
            {
                var resultsCustomerID = await _customerShoppingCartContext.Customers.FindAsync(customer.id);

                if (resultsCustomerID==null)
                {
                    return new NotFoundObjectResult($"No Customer with id = {customer.id} was found in the database");
                }

                _dataBaseChanges.Remove(resultsCustomerID);
                await _dataBaseChanges.CommitAsync();
                return new OkObjectResult($"Successfully deleted Customer with id = {customer.id}");
            }
            return new BadRequestObjectResult("Customer id cannot be null");
        }

        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var allcustomers = _customerShoppingCartContext.Customers.ToListAsync();
                return new OkObjectResult(allcustomers);
            }
            catch (Exception e)
            {
                await Task.Delay(0);
                return new BadRequestObjectResult($"Unable get all customers {e.Message}");
            }
        }

        public async Task<IActionResult> GetCustomerWithID(int id)
        {
            if (id!=0)
            {
                try
                {
                    var customers = _customerShoppingCartContext.Customers.FindAsync(id);
                    return new OkObjectResult(customers);
                }
                catch (Exception e)
                {
                    await Task.Delay(0);
                    return new BadRequestObjectResult($"Unable get all customers {e.Message}");
                }
            }
            return new BadRequestObjectResult("Customer Id cannot be null");
        }

        public async Task<IActionResult> ChangeState(int id)
        {
            if (id != 0)
            {
                var resultsCustomerID = await _customerShoppingCartContext.Customers.FindAsync(id);

                if (resultsCustomerID == null)
                {
                    return new NotFoundObjectResult($"No Customer with id = {id} was found in the database");
                }

                resultsCustomerID.IsActive = false;

                //To solve the problem of tracking entity. Make sure entity is in stable state
                _dataBaseChanges.Update(resultsCustomerID);
                await _dataBaseChanges.CommitAsync();
                _customerShoppingCartContext.Entry(resultsCustomerID).State = EntityState.Detached;
                return new OkObjectResult($"Successfully Updated Customer with id = {id}");
            }
            return new BadRequestObjectResult("Customer cannot be null");
        }

        public async Task<IActionResult> GetActiveCustomers()
        {
            try
            {
                var allActiveCustomers = _customerShoppingCartContext.Customers.Where(x => x.IsActive != false).ToListAsync();
                return new OkObjectResult(allActiveCustomers);
            }
            catch (Exception e)
            {
                await Task.Delay(0);
                return new BadRequestObjectResult($"Unable get all active customers {e.Message}");
            }
        }

        public async Task<IActionResult> UpdateExistingCustomer(Customer customer)
        {
            if (customer != null)
            {
                var resultsCustomerID = await _customerShoppingCartContext.Customers.FindAsync(customer.id);

                if (resultsCustomerID == null)
                {
                    return new NotFoundObjectResult($"No Customer with id = {customer.id} was found in the database");
                }

                //To solve the problem of tracking entity. Make sure entity is in stable state
                _dataBaseChanges.Update(resultsCustomerID);
                await _dataBaseChanges.CommitAsync();
                _customerShoppingCartContext.Entry(resultsCustomerID).State = EntityState.Detached;
                return new OkObjectResult($"Successfully Updated Customer with id = {customer.id}");
            }
            return new BadRequestObjectResult("Customer cannot be null");
        }
    }
}
