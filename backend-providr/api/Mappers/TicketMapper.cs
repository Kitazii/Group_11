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
                Service_Request_Date = ticketModel.Service_Request_Date
            }; 
        }

        public static Ticket ToTicketFromCreateDTO(this CreateTicketRequestDto ticketDto)
        {
            return new Ticket
            {
                Service_Request_Name = ticketDto.Service_Request_Name,
                Service_Request_Date = ticketDto.Service_Request_Date
            };
        }
    }
}