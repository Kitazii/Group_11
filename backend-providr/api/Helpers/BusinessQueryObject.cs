using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    //Used when user queries/searches for different businesses. Ensures successful page rollover.
    public class BusinessQueryObject
    {
        public string? Name { get; set; } = null;
        public string? BusinessTypeValue { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}