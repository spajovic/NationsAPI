using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Dto.CountryFlags
{
    public class DeleteCountryFlagDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
    }
}
