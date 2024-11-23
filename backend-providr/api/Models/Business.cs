using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Business")]
    public class Business : AppUser
    {
        public string Name { get; set; } = string.Empty;
        public BusinessType? BusinessType { get; set; }
    }

    public enum BusinessType
    {
        Electrition, Plumber, Painter, Plasterer, Break_Layer
    }
}