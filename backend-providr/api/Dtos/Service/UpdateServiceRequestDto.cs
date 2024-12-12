using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Service
{
    //Used when parsing objects to server side, for JSON transformation. Extra step to ensure data security.
    public class UpdateServiceRequestDto
    {
        public string Service_Type { get; set; } = string.Empty;
        public string Service_Description { get; set; } = string.Empty;
        public decimal Service_Cost { get; set; } = 0.0m;
    }
}