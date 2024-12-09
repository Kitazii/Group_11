using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDBContext _context;
        public ServiceRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<MyService> CreateServiceAsync(MyService servicedModel)
        {
            await _context.Services.AddAsync(servicedModel);
            await _context.SaveChangesAsync();
            return servicedModel;
        }

        public async Task<MyService?> DeleteServiceAsync(int id)
        {
            var servicedModel = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);

            if(servicedModel == null) return null;

            _context.Services.Remove(servicedModel);

            await _context.SaveChangesAsync();

            return servicedModel;
        }

        public async Task<List<MyService>> GetAllAsync()
        {
            return await _context.Services.Include(s => s.Workers).ToListAsync();
        }

        public async Task<MyService?> GetByIdAsync(int id)
        {
            return await _context.Services.Include(s => s.Workers).FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task<bool> ServiceExists(int id)
        {
            return _context.Services.AnyAsync(s => s.Id == id);
        }

        public async Task<MyService?> UpdateServiceAsync(int id)
        {
            var servicedModel = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);

            if(servicedModel == null) return null;

            await _context.SaveChangesAsync();

            return servicedModel;
        }
    }
}