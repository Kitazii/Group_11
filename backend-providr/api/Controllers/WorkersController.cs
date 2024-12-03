using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Workers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/workers")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkersRepository _workersRepo;
        public WorkersController(IWorkersRepository workersRepo)
        {
            _workersRepo = workersRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var workers = await _workersRepo.GetAllAsync();
            var workersDto = workers.Select(s => s.ToWorkersDto());

            return Ok(workersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            var workers = await _workersRepo.GetByIdAsync(id);

            if(workers == null) return NotFound();

            return Ok(workers.ToWorkersDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWorkersRequestDto workersDto)
        {
            var workersModel = workersDto.ToWorkersFromCreateDTO();

            await _workersRepo.CreateWorkersAsync(workersModel);

            return CreatedAtAction(nameof(GetById), new { id = workersModel.Id}, workersModel.ToWorkersDto());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateWorkersRequestDto updateDto)
        {
            //fetch the existing workers by ID from the database
            var existingWorkers = await _workersRepo.GetByIdAsync(id);

            //check if the workers exists
            if (existingWorkers == null)
            {
                return NotFound();
            }
            var workersModel = updateDto.ToWorkersFromUpdateDto(existingWorkers);

            if(workersModel == null) return NotFound();

            return Ok(workersModel.ToWorkersDto());
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id )
        {
            var workersModel = await _workersRepo.DeleteWorkersAsync(id);

            if(workersModel == null) return NotFound();

            return NoContent();
            
        }
    }
}