using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Business;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/business")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBusinessRepository _businessRepo;
        public  BusinessController(ApplicationDBContext context, IBusinessRepository businessRepo )
        {
            _businessRepo = businessRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var businesses = await _businessRepo.GetAllAsync();
            var businessDto = businesses.Select(b => b.ToBusinessDto() ) ;

            return Ok(businessDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id) 
        {
            var business = await _context.Businesses.FindAsync(id);

            if(business == null)
            {
                return NotFound();
            }

            return Ok(business.ToBusinessDto());
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateBusinessRequestDto businessDto)
        {
            var businessModel = businessDto.ToBusinessFromCreateDTO();
            await _context.Businesses.AddAsync(businessModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = businessModel.Id}, businessModel.ToBusinessDto());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateBusinessRequestDto updateDto)
        {
            var businessModel = await _context.Businesses.FirstOrDefaultAsync(b => b.Id == id);

            if(businessModel == null)
            {
                return NotFound();
            }

            businessModel.Name = updateDto.Name;
            businessModel.Email = updateDto.Email;
            businessModel.PhoneNumber = updateDto.PhoneNumber;
            businessModel.Street = updateDto.Street;
            businessModel.City = updateDto.City;
            businessModel.Postcode = updateDto.Postcode;

            await _context.SaveChangesAsync();

            return Ok(businessModel.ToBusinessDto());
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id )
        {
            var businessModel = await _context.Businesses.FirstOrDefaultAsync(b => b.Id == id);

            if(businessModel == null)
            {
                return NotFound();
            }

            _context.Businesses.Remove(businessModel);

            await _context.SaveChangesAsync();

            return NoContent();
            
        }
    }
}