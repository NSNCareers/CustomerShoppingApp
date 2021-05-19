using CustomerShoppingApp.Context;
using CustomerShoppingApp.DAL;
using CustomerShoppingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
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

                    return new CreatedResult($"Successfully created customer with ID = {customer.id}", customer);
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult($"Unable to create Customer due to exception: {e.InnerException}");
                }
            }

            return new BadRequestObjectResult("Customer object cannot be null");
        }

        public async Task<IActionResult> DeletCustomer(int id)
        {
            if (id != 0)
            {
                try
                {
                    var resultsCustomerID = await _customerShoppingCartContext.Customers.FindAsync(id);

                    if (resultsCustomerID == null)
                    {
                        return new NotFoundObjectResult($"No Customer with id = {id} was found in the database");
                    }

                    _dataBaseChanges.Remove(resultsCustomerID);
                    await _dataBaseChanges.CommitAsync();
                    return new OkObjectResult($"Successfully deleted Customer with id = {id}");
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult($"Unable to delete Customer due to exception: {e.InnerException}");
                }
            }
            return new BadRequestObjectResult("Customer id cannot be null");
        }

        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var allcustomers = await _customerShoppingCartContext.Customers
                    .Include(a => a.address)
                    .Include(a => a.bankDetail)
                    .Include(a => a.shoppingCart.item)
                    .Include(a => a.shoppingCart.item.shoe)
                    .Include(a => a.shoppingCart.item.garden)
                    .Include(a => a.shoppingCart.item.furniture)
                    .Include(a => a.shoppingCart.item.cloth)
                    .AsNoTracking()
                    .ToListAsync();
                if (allcustomers.Count == 0)
                {
                    return new OkObjectResult("No Customers exist in database, PLEASE USE POST REQUEST TO CREATE A NEW CUSTOMER OBJECT");
                }
                return new OkObjectResult(allcustomers);
            }
            catch (Exception e)
            {
                await Task.Delay(0);
                return new BadRequestObjectResult($"Unable get all customers {e.InnerException}");
            }
        }

        public async Task<IActionResult> GetCustomerWithID(int id)
        {
            if (id!=0)
            {
                try
                {
                    var customer = await _customerShoppingCartContext.Customers
                        .Include(a => a.address)
                        .Include(a => a.bankDetail)
                        .Include(a => a.shoppingCart.item)
                        .Include(a => a.shoppingCart.item.shoe)
                        .Include(a => a.shoppingCart.item.garden)
                        .Include(a => a.shoppingCart.item.furniture)
                        .Include(a => a.shoppingCart.item.cloth)
                        .Where(a => a.id == id)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
                    if (customer != null)
                    {
                        return new OkObjectResult(customer);
                    }
                    else
                    {
                        return new OkObjectResult($"Customer with ID: {id} does not exist in database");
                    }
                }
                catch (Exception e)
                {
                    await Task.Delay(0);
                    return new BadRequestObjectResult($"Unable get all customers {e.InnerException}");
                }
            }
            return new BadRequestObjectResult("Customer Id cannot be null");
        }

        public async Task<IActionResult> ChangeState(int id)
        {
            if (id != 0)
            {
                var customerState = "";

                var resultsCustomerID = await _customerShoppingCartContext.Customers.FindAsync(id);

                if (resultsCustomerID == null)
                {
                    return new NotFoundObjectResult($"No Customer with id = {id} was found in the database");
                }

                if (resultsCustomerID.IsActive == true)
                {
                    resultsCustomerID.IsActive = false;
                    customerState = "InActive";
                }
                else
                {
                    resultsCustomerID.IsActive = true;
                    customerState = "Active";
                }

                //To solve the problem of tracking entity. Make sure entity is in stable state
                _dataBaseChanges.Update(resultsCustomerID);
                await _dataBaseChanges.CommitAsync();
                _customerShoppingCartContext.Entry(resultsCustomerID).State = EntityState.Detached;
                return new OkObjectResult($"Customer with id = {id} is now in {customerState} state");
            }
            return new BadRequestObjectResult("Customer cannot be null");
        }

        public async Task<IActionResult> GetActiveCustomers()
        {
            try
            {
                var allActiveCustomers = await _customerShoppingCartContext.Customers
                    .Include(a => a.address)
                    .Include(a => a.bankDetail)
                    .Include(a => a.shoppingCart.item)
                    .Include(a => a.shoppingCart.item.shoe)
                    .Include(a => a.shoppingCart.item.garden)
                    .Include(a => a.shoppingCart.item.furniture)
                    .Include(a => a.shoppingCart.item.cloth)
                    .Where(x => x.IsActive != false)
                    .AsNoTracking()
                    .ToListAsync();

                if (allActiveCustomers.Count == 0)
                {
                    return new OkObjectResult("No active Customers exist in database, PLEASE USE POST REQUEST TO CREATE A NEW CUSTOMER OBJECT");
                }
                return new OkObjectResult(allActiveCustomers);
            }
            catch (Exception e)
            {
                await Task.Delay(0);
                return new BadRequestObjectResult($"Unable get all active customers {e.InnerException}");
            }
        }

        public async Task<IActionResult> GetInActiveCustomers()
        {
            try
            {
                var allInActiveCustomers = await _customerShoppingCartContext.Customers
                    .Include(a => a.address)
                    .Include(a => a.bankDetail)
                    .Include(a => a.shoppingCart.item)
                    .Include(a => a.shoppingCart.item.shoe)
                    .Include(a => a.shoppingCart.item.garden)
                    .Include(a => a.shoppingCart.item.furniture)
                    .Include(a => a.shoppingCart.item.cloth)
                    .Where(x => x.IsActive != true)
                    .AsNoTracking()
                    .ToListAsync();

                if (allInActiveCustomers.Count == 0)
                {
                    return new OkObjectResult("No inActive Customers exist in database, PLEASE USE POST REQUEST TO CREATE A NEW CUSTOMER OBJECT");
                }
                return new OkObjectResult(allInActiveCustomers);
            }
            catch (Exception e)
            {
                await Task.Delay(0);
                return new BadRequestObjectResult($"Unable get all inActive customers {e.InnerException}");
            }
        }

        public async Task<IActionResult> UpdateExistingCustomer(Customer customer)
        {
            if (customer != null)
            {
                var resultsCustomerID = await _customerShoppingCartContext.Customers
                        .Include(a => a.address)
                        .Include(a => a.bankDetail)
                        .Include(a => a.shoppingCart.item)
                        .Include(a => a.shoppingCart.item.shoe)
                        .Include(a => a.shoppingCart.item.garden)
                        .Include(a => a.shoppingCart.item.furniture)
                        .Include(a => a.shoppingCart.item.cloth)
                        .Where(a => a.id == customer.id)
                        .FirstOrDefaultAsync();

                if (resultsCustomerID == null)
                {
                    return new NotFoundObjectResult($"No Customer with id = {customer.id} was found in the database");
                }

                
                //To solve the problem of tracking entity. Make sure entity is in stable state
                _customerShoppingCartContext.Entry(resultsCustomerID).State = EntityState.Detached;
                _dataBaseChanges.Update(customer.address);
                _dataBaseChanges.Update(customer.bankDetail);
                _dataBaseChanges.Update(customer.shoppingCart.item);
                _dataBaseChanges.Update(customer.shoppingCart.item.shoe);
                _dataBaseChanges.Update(customer.shoppingCart.item.furniture);
                _dataBaseChanges.Update(customer.shoppingCart.item.cloth);
                _dataBaseChanges.Update(customer.shoppingCart.item.garden);
                var changes = _customerShoppingCartContext.ChangeTracker.HasChanges();
                await _dataBaseChanges.CommitAsync();
                
                if (!changes)
                {
                    return new OkObjectResult($"No changes are being tracked for customer with id = {customer.id}");
                }
                return new OkObjectResult($"Successfully Updated Customer with id = {customer.id}");
            }
            return new BadRequestObjectResult("Customer cannot be null");
        }

        public async Task<IActionResult> GetCustomersAddress(int id, string firstName)
        {
            if (id != 0)
            {
                try
                {
                    var customer = await _customerShoppingCartContext.Customers
                        .Include(a => a.address)
                        .Where(a => a.id == id && a.firstName == firstName)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
                    if (customer != null)
                    {
                        return new OkObjectResult(customer);
                    }
                    else
                    {
                        return new OkObjectResult($"Customer with ID: {id} and FirstName {firstName} does not exist in database");
                    }
                }
                catch (Exception e)
                {
                    await Task.Delay(0);
                    return new BadRequestObjectResult($"Unable get all customers {e.InnerException}");
                }
            }
            return new BadRequestObjectResult("Customer Id cannot be null");
        }

        public async Task<IActionResult> GetCustomersItems(int id, string firstName)
        {
            if (id != 0)
            {
                try
                {
                    var customer = await _customerShoppingCartContext.Customers
                        .Include(a => a.shoppingCart.item)
                        .Include(a => a.shoppingCart.item.shoe)
                        .Include(a => a.shoppingCart.item.garden)
                        .Include(a => a.shoppingCart.item.furniture)
                        .Include(a => a.shoppingCart.item.cloth)
                        .Where(a => a.id == id && a.firstName == firstName)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
                    if (customer != null)
                    {
                        return new OkObjectResult(customer);
                    }
                    else
                    {
                        return new OkObjectResult($"Customer with ID: {id} and FirstName {firstName} does not exist in database");
                    }
                }
                catch (Exception e)
                {
                    await Task.Delay(0);
                    return new BadRequestObjectResult($"Unable get all customers {e.InnerException}");
                }
            }
            return new BadRequestObjectResult("Customer Id cannot be null");
        }
        public async Task<IActionResult> GetCustomersBankdetails(int id, string firstName)
        {
            if (id != 0)
            {
                try
                {
                    var customer = await _customerShoppingCartContext.Customers
                        .Include(a => a.address)
                        .Where(a => a.id == id && a.firstName == firstName)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
                    if (customer != null)
                    {
                        return new OkObjectResult(customer);
                    }
                    else
                    {
                        return new OkObjectResult($"Customer with ID: {id} and FirstName {firstName} does not exist in database");
                    }
                }
                catch (Exception e)
                {
                    await Task.Delay(0);
                    return new BadRequestObjectResult($"Unable get all customers {e.InnerException}");
                }
            }
            return new BadRequestObjectResult("Customer Id cannot be null");
        }
    }
}
