using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions) {}

        public required DbSet<Business> Businesses{ get; set; }
        public required DbSet<Customer> Customers { get; set; }
        public required DbSet<Ticket> Tickets{ get; set; }
    }
}