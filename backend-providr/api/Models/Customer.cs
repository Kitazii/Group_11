using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Customer : AppUser
    {
        public string? Forename { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public CustomerType? CustomerType { get; set; } = 0;
        public string? CustomerTypeValue { get; set; } = string.Empty;
    }

    public enum CustomerType
    {
        Premium, Standard, Corporate
    }
}