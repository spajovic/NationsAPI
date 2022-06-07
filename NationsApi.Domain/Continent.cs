using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Domain
{
    public class Continent : BaseEntity
    {
        public string Name { get; set; }

        // Collections
        public ICollection<Region> Regions { get; set; } = new HashSet<Region>();
    }
}
