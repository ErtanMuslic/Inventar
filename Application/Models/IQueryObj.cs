﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class IQueryObj
    {
        public string? SortBy { get; set; }
        public bool? IsSortAscending { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }

    }
}
