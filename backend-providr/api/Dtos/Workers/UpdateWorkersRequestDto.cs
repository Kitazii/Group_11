using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Service;
using api.Dtos.Ticket;

namespace api.Dtos.Workers
{
    public class UpdateWorkersRequestDto
    {
        public int Service_Workers_Quantity { get; set; }
    }
}