using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Service;
using api.Dtos.Ticket;

namespace api.Dtos.Workers
{
    //Used when parsing objects to server side, for JSON transformation. Extra step to ensure data security.
    public class WorkersDto
    {
        public int Id { get; set; }
        public int Service_Workers_Quantity { get; set; }
         //Nav Prop - One
        public int? ServiceId { get; set; } = null;
        public int? TicketId { get; set; } = null;
    }
}