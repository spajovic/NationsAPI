using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Domain
{
    public class Region : BaseEntity
    {
        public string Name { get; set; }
        public int ContinentId { get; set; }
        public ICollection<Country> Countries { get; set; } = new HashSet<Country>();
        public virtual Continent Continent { get; set; }

    }
}
