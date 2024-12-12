using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Business.Enum;

namespace api.Dtos.Business
{
    public class CreateBusinessRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public BusinessType? BusinessType { get; set; }
    }
}