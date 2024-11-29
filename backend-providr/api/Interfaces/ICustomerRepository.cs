using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync(CustomerQueryObject query);
        Task<Customer?> GetByIdAsync(string id);
        Task<Customer> CreateCustomerAsync(Customer customerModel);
        Task<Customer?> UpdateCustomerAsync(string id);
        Task<Customer?> DeleteCustomerAsync(string id);
        Task<bool> CustomerExists(string id);
    }
}