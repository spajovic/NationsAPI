﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Searches
{
    public class UserSearch : BaseSearch
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? RoleName { get; set; }
        public int? RoleId { get; set; }
        public string? Email { get; set; }
    }
}
