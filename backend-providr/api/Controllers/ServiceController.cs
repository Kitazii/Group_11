using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Service;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepo;
        public ServiceController(IServiceRepository serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var services = await _serviceRepo.GetAllAsync();
            var serviceDto = services.Select(ms => ms.ToServiceDto());

            return Ok(serviceDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            var service = await _serviceRepo.GetByIdAsync(id);

            if(service == null) return NotFound();

            return Ok(service.ToServiceDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateServiceRequestDto serviceDto)
        {
            var serviceModel = serviceDto.ToServiceFromCreateDto();

            await _serviceRepo.CreateServiceAsync(serviceModel);

            return CreatedAtAction(nameof(GetById), new { id = serviceModel.Id}, serviceModel.ToServiceDto());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateServiceRequestDto updateDto)
        {
            //fetch the existing service by ID from the database
            var existingService = await _serviceRepo.GetByIdAsync(id);

            //check if the service exists
            if (existingService == null)
            {
                return NotFound();
            }
            var serviceModel = updateDto.ToServiceFromUpdateDto(existingService);

            if(existingService == null) return NotFound();

            return Ok(existingService.ToServiceDto());
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id )
        {
            var serviceModel = await _serviceRepo.DeleteServiceAsync(id);

            if(serviceModel == null) return NotFound();

            return NoContent();
            
        }
    }
}