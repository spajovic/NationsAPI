using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Searches
{
    public class UseCaseLogSearch
    {
        public string? ActorName { get; set; }
        public string? UseCaseName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? Page { get; set; }
        public int? ItemsPerPage { get; set; }
    }
}
