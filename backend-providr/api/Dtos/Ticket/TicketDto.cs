using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Ticket
{
    public class TicketDto
    {
         public int Id { get; set;}

        public string Service_Request_Name { get; set;} = string.Empty;
        public DateTime Service_Request_Date{ get; set;}  = DateTime.Now;
        public DateTime Service_Updated_Date{ get; set;} = DateTime.Now;

        //NAV PROP - One User
        //public int? UserId { get; set; }
        //public AppUser? User { get; set; }
    }
    }
