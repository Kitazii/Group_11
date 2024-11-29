using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Business;
using api.Helpers;
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
        private readonly IBusinessRepository _businessRepo;
        public  BusinessController(IBusinessRepository businessRepo )
        {
            _businessRepo = businessRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BusinessQueryObject query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var businesses = await _businessRepo.GetAllAsync(query);
            var businessDto = businesses.Select(b => b.ToBusinessDto() ) ;

            return Ok(businessDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id) 
        {
            var business = await _businessRepo.GetByIdAsync(id);

            if(business == null) return NotFound();

            return Ok(business.ToBusinessDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBusinessRequestDto businessDto)
        {
            var businessModel = businessDto.ToBusinessFromCreateDTO();

            await _businessRepo.CreateBusinessAsync(businessModel);

            return CreatedAtAction(nameof(GetById), new { id = businessModel.Id}, businessModel.ToBusinessDto());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateBusinessRequestDto updateDto)
        {
            //fetch the existing business by ID from the database
            var existingBusiness = await _businessRepo.GetByIdAsync(id);

            //check if the business exists
            if (existingBusiness == null)
            {
                return NotFound();
            }
            var businessModel = updateDto.ToBusinessFromUpdateDto(existingBusiness);

            if(businessModel == null) return NotFound();

            return Ok(businessModel.ToBusinessDto());
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id )
        {
            var businessModel = await _businessRepo.DeleteBusinessAsync(id);

            if(businessModel == null) return NotFound();

            return NoContent();
        }
    }
}