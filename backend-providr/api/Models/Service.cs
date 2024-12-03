using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Service_Type { get; set; } = string.Empty;
        public string Service_Description { get; set; } = string.Empty;
        public decimal Service_Cost { get; set; } = 0.0m;

        //Nav Prop - Many
        public List<Workers_On_Ticket>? Workers { get; set; } = null;
    }
}