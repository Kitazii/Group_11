using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
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
        public required DbSet<Workers_On_Ticket> Workers { get; set; }
        public required DbSet<MyService> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Primary key
            builder.Entity<Workers_On_Ticket>()
                .HasKey(w => w.Id);

            builder.Entity<Workers_On_Ticket>()
                .HasOne(s => s.Service)
                .WithMany(s => s.Workers)
                .HasForeignKey(w => w.ServiceId);

            builder.Entity<Workers_On_Ticket>()
                .HasOne(t => t.Ticket)
                .WithMany(t => t.Workers)
                .HasForeignKey(w => w.TicketId);

            // Configure Ticket
            builder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId);

            // Configure Service
            builder.Entity<MyService>()
                .HasMany(s => s.Workers)
                .WithOne(w => w.Service)
                .HasForeignKey(w => w.ServiceId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Business",
                    NormalizedName = "BUSINESS"
                },
                new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}