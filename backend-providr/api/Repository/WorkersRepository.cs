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
    public class WorkersRepository : IWorkersRepository
    {
        private readonly ApplicationDBContext _context;

        public WorkersRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Workers_On_Ticket> CreateWorkersAsync(Workers_On_Ticket workersModel)
        {
            await _context.Workers.AddAsync(workersModel);
            await _context.SaveChangesAsync();
            return workersModel;
        }

        public async Task<Workers_On_Ticket?> DeleteWorkersAsync(int id)
        {
           var workersModel = await _context.Workers.FirstOrDefaultAsync(w => w.Id == id);

            if(workersModel == null) return null;

            _context.Workers.Remove(workersModel);

            await _context.SaveChangesAsync();

            return workersModel;
        }

        public async Task<List<Workers_On_Ticket>> GetAllAsync()
        {
            return await _context.Workers.ToListAsync();
        }

        public async Task<Workers_On_Ticket?> GetByIdAsync(int id)
        {
            return await _context.Workers.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<Workers_On_Ticket?> UpdateWorkersAsync(int id)
        {
            var workersModel = await _context.Workers.FirstOrDefaultAsync(w => w.Id == id);

            if(workersModel == null) return null;

            await _context.SaveChangesAsync();

            return workersModel;
        }
    }
}