using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IBusinessRepository
    {
        Task<List<Business>> GetAllAsync(BusinessQueryObject query);
        Task<Business?> GetByIdAsync(string id);
        Task<Business> CreateBusinessAsync(Business businessModel);
        Task<Business?> UpdateBusinessAsync(string id);
        Task<Business?> DeleteBusinessAsync(string id);
        Task<bool> BusinessExists(string id);
    }
}