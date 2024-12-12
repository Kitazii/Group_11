using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using api.Dtos.Ticket;
using api.Models;
using Microsoft.AspNetCore.Components.Web;

namespace api.Mappers
{
    public static class TicketMapper
    {
        public static TicketDto ToTicketDto (this Ticket ticketModel)
        {
            return new TicketDto
            {
                Id = ticketModel.Id,
                Service_Request_Name = ticketModel.Service_Request_Name,
                Service_Request_Date = ticketModel.Service_Request_Date,
                UserId = ticketModel.UserId,
                Workers = ticketModel.Workers.Select(w => w.ToWorkersDto()).ToList()
            }; 
        }

        public static Ticket ToTicketFromCreateDTO(this CreateTicketRequestDto ticketDto)
        {
            return new Ticket
            {
                Service_Request_Name = ticketDto.Service_Request_Name,
                Service_Request_Date = ticketDto.Service_Request_Date,
                UserId = ticketDto.UserId
            };
        }

        public static Ticket ToTicketFromUpdateDto(this UpdateTicketRequestDto ticketDto, Ticket existingticket)
        {
            return new Ticket
            {
                Id = existingticket.Id,
                Service_Request_Name = string.IsNullOrWhiteSpace(ticketDto.Service_Request_Name) ? existingticket.Service_Request_Name : ticketDto.Service_Request_Name,
                Service_Request_Date = existingticket.Service_Request_Date,
                Service_Updated_Date = ticketDto.Service_Updated_Date,
                UserId = existingticket.UserId,
                User = existingticket.User,
                Workers = existingticket.Workers
            };
        }
    }
}