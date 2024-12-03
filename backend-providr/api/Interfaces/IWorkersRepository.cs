using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IWorkersRepository
    {
        Task<List<Workers_On_Ticket>> GetAllAsync();
        Task<Workers_On_Ticket?> GetByIdAsync(int id);
        Task<Workers_On_Ticket> CreateWorkersAsync(Workers_On_Ticket WorkersModel);
        Task<Workers_On_Ticket?> UpdateWorkersAsync(int id);
        Task<Workers_On_Ticket?> DeleteWorkersAsync(int id);
    }
}