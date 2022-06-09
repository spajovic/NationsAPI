using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Searches
{
    public class CountrySearch : BaseSearch
    {
        public string? Name { get; set; }
        public string? RegionName { get; set; }
        public string? UserName { get; set; }
        public string? ContinentName { get; set; }
        public string? CountryCode { get; set; }
    }
}
