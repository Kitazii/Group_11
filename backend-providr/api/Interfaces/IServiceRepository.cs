using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IServiceRepository
    {
        Task<List<MyService>> GetAllAsync();
        Task<MyService?> GetByIdAsync(int id);
        Task<MyService> CreateServiceAsync(MyService servicedModel);
        Task<MyService?> UpdateServiceAsync(int id);
        Task<MyService?> DeleteServiceAsync(int id);
        Task<bool> ServiceExists(int id);
    }
}