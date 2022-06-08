using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Dto.Regions
{
    public class GetRegionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Countries { get; set; }
        public string ContinentName { get; set; }
        public int ContinentId { get; set; }
    }
}
