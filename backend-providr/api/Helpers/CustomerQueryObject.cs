using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    //Used when user queries/searches for different customers. Ensures successful page rollover.
    public class CustomerQueryObject
    {
        public string? Forename { get; set; } = null;
        public string? Surname { get; set; } = null;
        public string? CustomerTypeValue { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}