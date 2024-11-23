using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Customer : AppUser
    {
        public CustomerType? CustomerType { get; set; }
    }

    public enum CustomerType
    {
        Premium, Standard, Corporate
    }
}