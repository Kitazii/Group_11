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
            // Retrieve existing Customer and Business entities thatt belong to the ticket from the database
           // var existingUser = await _context.Businesses.FindAsync(ticketModel.UserId);

            //if (existingUser == null)
            //{
               // throw new Exception("user not found");
            //}

            // Associate the existing entities
            //ticketModel.User = existingUser;
            
            await _context.Tickets.AddAsync(ticketModel);
            await _context.SaveChangesAsync();
            return ticketModel;
        }

        public async Task<Ticket?> DeleteTicketAsync(int id)
        {
            var ticketModel = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);

            if(ticketModel == null) return null;

            _context.Tickets.Remove(ticketModel);

            await _context.SaveChangesAsync();

            return ticketModel;
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.Include(t => t.Workers).ToListAsync();
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
        }

        public Task<bool> TicketExists(int id)
        {
            return _context.Tickets.AnyAsync(t => t.Id == id);
        }

        public async Task<Ticket?> UpdateTicketAsync(int id)
        {
            var ticketModel = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);

            if(ticketModel == null) return null;

            await _context.SaveChangesAsync();

            return ticketModel;
        }
    }
}