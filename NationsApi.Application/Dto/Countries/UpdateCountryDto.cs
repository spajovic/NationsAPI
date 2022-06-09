using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Dto.Countries
{
    public class UpdateCountryDto : AddCountryDto
    {
        public int Id { get; set; }
    }
}
