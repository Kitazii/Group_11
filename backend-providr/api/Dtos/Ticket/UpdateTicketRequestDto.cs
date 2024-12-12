using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Ticket
{
    //Used when parsing objects to server side, for JSON transformation. Extra step to ensure data security.
    public class UpdateTicketRequestDto
    {
        public string Service_Request_Name { get; set;} = string.Empty;
        public DateTime Service_Updated_Date{ get; set;} = DateTime.Now;
    }
}