using NationsApi.Application.Dto.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Dto.Countries
{
    public class GetCountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }
        public DateTime NationalDay { get; set; }
        public string CountryCode { get; set; }
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public GetUserDto User { get; set; }
    }
}
