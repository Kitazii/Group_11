using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    //Buisnesss logic models for Workers assigned to a job
    public class Workers_On_Ticket
    {
        public int Id { get; set; }
        public int Service_Workers_Quantity { get; set; }

        //Nav Prop - One
        public int ServiceId { get; set; }
        public MyService Service { get; set; } = new();

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = new();
    }
}