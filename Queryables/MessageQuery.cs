using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashApi.Queryables
{
    public class MessageQuery
    {
        public string? Content { get; set; } = null;

        public bool Old { get; set; } = false;

        //public string? SortBy { get; set; } = null;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}