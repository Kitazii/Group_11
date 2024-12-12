using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Customer.Enum;

namespace api.Dtos.Customer
{
    public class CustomerDto
    {
        public string Id { get; set; } = string.Empty;
        public string Forename { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string Password { get; set; } = "";
        public string? PhoneNumber { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public CustomerType? CustomerType { get; set; }
        public string CustomerTypeValue { get; set; } = string.Empty;
        public string? Token { get; set; }
    }
}