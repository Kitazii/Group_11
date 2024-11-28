using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllAsync();
        Task<Ticket?> GetByIdAsync(int id);
        Task<Ticket> CreateTicketAsync(Ticket ticketModel);
        Task<Ticket?> UpdateTicketAsync(int id);
        Task<Ticket?> DeleteTicketAsync(int id);
    }
}