using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Respository
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly ApplicationDBContext _context; //comment
        public BusinessRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<Business>> GetAllAsync()
        {
            return _context.Businesses.ToListAsync();
        }
    }
}