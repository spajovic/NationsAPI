using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Dto.CountryFlags
{
    public class AddCountryFlagDto
    {
        public int CountryId { get; set; }
        public IFormFile FilePath { get; set; }
    }
}
