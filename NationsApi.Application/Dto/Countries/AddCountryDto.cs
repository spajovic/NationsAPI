using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Dto.Countries
{
    public class AddCountryDto
    {
        public string Name { get; set; }
        public decimal Area { get; set; }
        public DateTime? NationalDay { get; set; }
        public string CountryCode { get; set; }
        public int RegionId { get; set; }
        public int UserId { get; set; }
    }
}
