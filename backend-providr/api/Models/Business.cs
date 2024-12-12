using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace api.Models
{
    //Buisnesss logic models for Businesses
    //inherits from AppUser
    [Table("Business")]
    public class Business : AppUser
    {
        public string Name { get; set; } = string.Empty;
        public BusinessType? BusinessType { get; set; } = 0;
        public string BusinessTypeValue { get; set; } = string.Empty;
    }

    public enum BusinessType
    {
        Electrition, Plumber, Painter, Plasterer, Brick_Layer
    }
}