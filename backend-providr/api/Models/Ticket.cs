using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Ticket
    {
        public int Id { get; set;}

        public string Service_Request_Name { get; set;} = string.Empty;
        public DateTime Service_Request_Date{ get; set;} = DateTime.Now;
        public DateTime Service_Updated_Date{ get; set;} = DateTime.Now;

        //Nav Prop - ONE
        public int? UserId { get; set; } = null;
        public AppUser? User { get; set; } = null;

        //Nav Prop - MANY
        public List<Workers>? Workers { get; set; } = null;

    }
}