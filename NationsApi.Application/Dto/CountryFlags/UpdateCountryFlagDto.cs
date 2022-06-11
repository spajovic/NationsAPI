using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Dto.CountryFlags
{
    public class UpdateCountryFlagDto : AddCountryFlagDto
    {
        public int Id { get; set; }
    }
}
