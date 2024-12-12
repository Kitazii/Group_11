using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    //Buisnesss logic models for Users
    //inherits from identity user - framework for to handle user security
    public class AppUser : IdentityUser
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;

        //NAV PROP - Many Tickets
        public List<Ticket>? Tickets { get; set; } = null;
    }
}