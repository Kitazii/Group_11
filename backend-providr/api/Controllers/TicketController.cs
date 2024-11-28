using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Ticket;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/ticket")]
    [ApiController]

    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepo;
        public TicketController(ITicketRepository ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var tickets = await _ticketRepo.GetAllAsync();
            var ticketDto = tickets.Select(s => s.ToTicketDto());

            return Ok(ticketDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            var ticket = await _ticketRepo.GetByIdAsync(id);

            if(ticket == null) return NotFound();

            return Ok(ticket.ToTicketDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTicketRequestDto ticketDto)
        {
            var ticketModel = ticketDto.ToTicketFromCreateDTO();

            await _ticketRepo.CreateTicketAsync(ticketModel);

            return CreatedAtAction(nameof(GetById), new { id = ticketModel.Id}, ticketModel.ToTicketDto());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTicketRequestDto updateDto)
        {
            //fetch the existing ticket by ID from the database
            var existingTicket = await _ticketRepo.GetByIdAsync(id);

            //check if the ticket exists
            if (existingTicket == null)
            {
                return NotFound();
            }
            var ticketModel = updateDto.ToTicketFromUpdateDto(existingTicket);

            if(ticketModel == null) return NotFound();

            return Ok(ticketModel.ToTicketDto());
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id )
        {
            var ticketModel = await _ticketRepo.DeleteTicketAsync(id);

            if(ticketModel == null) return NotFound();

            return NoContent();
            
        }

    }
}