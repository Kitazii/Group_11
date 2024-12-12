using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Business;
using api.Dtos.Customer;

namespace api.Dtos.Ticket
{
    //Used when parsing objects to server side, for JSON transformation. Extra step to ensure data security.
    public class CreateTicketRequestDto
    {
        public string Service_Request_Name { get; set;} = string.Empty;
        public DateTime Service_Request_Date{ get; set;}  = DateTime.Now;
        public DateTime Service_Updated_Date{ get; set;} = DateTime.Now;

        //NAV PROP - One User
        public string UserId { get; set; } = string.Empty;
    }
}