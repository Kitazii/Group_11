using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Customer;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerController(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CustomerQueryObject query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var customers = await _customerRepo.GetAllAsync(query);
            var customersDto = customers.Select(c => c.ToCustomerDto()) ;

            return Ok(customersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id) 
        {
            var customer = await _customerRepo.GetByIdAsync(id);

            if(customer == null) return NotFound();

            return Ok(customer.ToCustomerDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequestDto customerDto)
        {
            var customerModel = customerDto.ToCustomerFromCreateDTO();

            await _customerRepo.CreateCustomerAsync(customerModel);

            return CreatedAtAction(nameof(GetById), new { id = customerModel.Id}, customerModel.ToCustomerDto());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateCustomerRequestDto updateDto)
        {
            //fetch the existing customer by ID from the database
            var existingCustomer = await _customerRepo.GetByIdAsync(id);

            //check if the business exists
            if (existingCustomer == null)
            {
                return NotFound();
            }
            var customerModel = updateDto.ToCustomerFromUpdateDto(existingCustomer);

            if(customerModel == null) return NotFound();

            return Ok(customerModel.ToCustomerDto());
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id )
        {
            var customerModel = await _customerRepo.DeleteCustomerAsync(id);

            if(customerModel == null) return NotFound();

            return NoContent();
        }
    }
}