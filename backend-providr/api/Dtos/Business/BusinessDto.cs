using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Business.Enum;

namespace api.Dtos.Business
{
    //Used when parsing objects to server side, for JSON transformation. Extra step to ensure data security.
    public class BusinessDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public BusinessType? BusinessType { get; set; }
        public string BusinessTypeValue { get; set; } = string.Empty;
        public string? Token { get; set; }
        //NAV PROP - for Service Request

    }
}