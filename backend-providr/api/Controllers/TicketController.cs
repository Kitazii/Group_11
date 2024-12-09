using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        var tickets = await _ticketRepo.GetAllAsync();

        var ticketDto = tickets.Select(s => s.ToTicketDto());

        return Ok(ticketDto);
    }
}
}