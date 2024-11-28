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
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDBContext _context;
        public TicketRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Ticket> CreateTicketAsync(Ticket ticketModel)
        {
            await _context.Tickets.AddAsync(ticketModel);
            await _context.SaveChangesAsync();
            return ticketModel;
        }

        public Task<Ticket?> DeleteTicketAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public Task<Ticket?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket?> UpdateTicketAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}