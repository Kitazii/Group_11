using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    //Handles database manipulation logic for customers
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _context; //comment

        public CustomerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customerModel)
        {
            await _context.Customers.AddAsync(customerModel);
            await _context.SaveChangesAsync();
            return customerModel;
        }

        public Task<bool> CustomerExists(string id)
        {
            return _context.Customers.AnyAsync(c => c.Id == id);
        }

        public async Task<Customer?> DeleteCustomerAsync(string id)
        {
            var customerModel = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

            if(customerModel == null) return null;

            _context.Customers.Remove(customerModel);

            await _context.SaveChangesAsync();

            return customerModel;
        }

        public async Task<List<Customer>> GetAllAsync(CustomerQueryObject query)
        {
            var customers = _context.Customers.AsQueryable();

           if(!string.IsNullOrWhiteSpace(query.Forename))
           {
            customers = customers.Where(c => c.Forename.Contains(query.Forename));
           }

           if(!string.IsNullOrWhiteSpace(query.Surname))
           {
            customers = customers.Where(c => c.Surname.Contains(query.Surname));
           }

           if(!string.IsNullOrWhiteSpace(query.CustomerTypeValue))
           {
            customers = customers.Where(c => c.CustomerTypeValue.Contains(query.CustomerTypeValue));
           }

           if(!string.IsNullOrWhiteSpace(query.SortBy))
           {
            if(query.SortBy.Equals("BusinessTypeValue", StringComparison.OrdinalIgnoreCase))
            {
                customers = query.IsDecsending ? customers.OrderByDescending(c => c.CustomerTypeValue) : customers.OrderBy(b => b.CustomerTypeValue);
            }
           }

           var skipNumber = (query.PageNumber - 1) * query.PageSize;
           
           return await customers.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(string id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer?> UpdateCustomerAsync(string id)
        {
            var customersModel = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

            if(customersModel == null) return null;

            await _context.SaveChangesAsync();

            return customersModel;
        }
    }
}