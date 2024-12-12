using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Respository
{
    //Handles database manipulation logic for businesses
    public class BusinessRepository : IBusinessRepository
    {
        private readonly ApplicationDBContext _context; //comment
        public BusinessRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> BusinessExists(string id)
        {
            return _context.Businesses.AnyAsync(b => b.Id == id);
        }

        public async Task<Business> CreateBusinessAsync(Business businessModel)
        {
            await _context.Businesses.AddAsync(businessModel);
            await _context.SaveChangesAsync();
            return businessModel;
        }

        public async Task<Business?> DeleteBusinessAsync(string id)
        {
            var businessModel = await _context.Businesses.FirstOrDefaultAsync(b => b.Id == id);

            if(businessModel == null) return null;

            _context.Businesses.Remove(businessModel);

            await _context.SaveChangesAsync();

            return businessModel;
        }

        public async Task<List<Business>> GetAllAsync(BusinessQueryObject query)
        {
           var businesses = _context.Businesses.AsQueryable();

           if(!string.IsNullOrWhiteSpace(query.Name))
           {
            businesses = businesses.Where(b => b.Name.Contains(query.Name));
           }

           if(!string.IsNullOrWhiteSpace(query.BusinessTypeValue))
           {
            businesses = businesses.Where(b => b.BusinessTypeValue.Contains(query.BusinessTypeValue));
           }

           if(!string.IsNullOrWhiteSpace(query.SortBy))
           {
            if(query.SortBy.Equals("BusinessTypeValue", StringComparison.OrdinalIgnoreCase))
            {
                businesses = query.IsDecsending ? businesses.OrderByDescending(b => b.BusinessTypeValue) : businesses.OrderBy(b => b.BusinessTypeValue);
            }
           }

           var skipNumber = (query.PageNumber - 1) * query.PageSize;
           
           return await businesses.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Business?> GetByIdAsync(string id)
        {
            return await _context.Businesses.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Business?> UpdateBusinessAsync(string id)
        {
           var businessModel = await _context.Businesses.FirstOrDefaultAsync(b => b.Id == id);

            if(businessModel == null) return null;

            await _context.SaveChangesAsync();

            return businessModel;
        }
    }
}