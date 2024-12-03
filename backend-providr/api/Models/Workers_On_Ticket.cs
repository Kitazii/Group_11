using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Workers_On_Ticket
    {
        public int Id { get; set; }
        public int Service_Workers_Quantity { get; set; }

        //Nav Prop - One
        public int? ServiceId { get; set; } = null;
        public Service? Service { get; set; } = null;

        public int? TicketId { get; set; } = null;
        public Ticket? Ticket { get; set; } = null;
    }
}