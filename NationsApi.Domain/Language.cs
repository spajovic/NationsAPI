using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Domain
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }

        // Collections
        public ICollection<Country> Countries { get; set; } = new HashSet<Country>();
    }
}
