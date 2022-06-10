using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Dto.CountryStats
{
    public class RemoveCountryStatDto
    {
        public int CountryId { get; set; }
        public int Year { get; set; }
    }
}
