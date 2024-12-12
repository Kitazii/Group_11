using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    //Buisnesss logic models for Ticket
    public class Ticket
    {
        public int Id { get; set;}

        public string Service_Request_Name { get; set;} = string.Empty;
        public DateTime Service_Request_Date{ get; set;} = DateTime.Now;
        public DateTime Service_Updated_Date{ get; set;} = DateTime.Now;

        //Nav Prop - ONE
        public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; } = null;

        //Nav Prop - MANY
        public List<Workers_On_Ticket> Workers { get; set; } = new();

    }
}