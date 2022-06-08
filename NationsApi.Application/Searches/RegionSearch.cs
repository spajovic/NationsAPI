using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Searches
{
    public class RegionSearch : BaseSearch
    {
        public string? Name { get; set; }
        public string? CountryName { get; set; }
        public string?  ContinentName { get; set; }
    }
}
