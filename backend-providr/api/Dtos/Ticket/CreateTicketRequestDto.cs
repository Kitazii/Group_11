using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Ticket
{
    public class CreateTicketRequestDto
    {
        public string Service_Request_Name { get; set;} = string.Empty;
        public DateTime Service_Request_Date{ get; set;}  = DateTime.Now;
        public DateTime Service_Updated_Date{ get; set;} = DateTime.Now;
    }
}