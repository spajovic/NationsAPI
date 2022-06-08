using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Dto.Regions
{
    public class UpdateRegionDto : AddRegionDto
    {
        public int Id { get; set; }
    }
}
