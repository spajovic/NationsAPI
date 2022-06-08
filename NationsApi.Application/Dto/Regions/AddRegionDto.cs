using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Dto.Regions
{
    public class AddRegionDto
    {
        public string Name { get; set; }
        public int ContinentId { get; set; }
    }
}
