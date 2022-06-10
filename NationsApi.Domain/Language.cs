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
        public ICollection<CountryLanguage> CountryLanguages { get; set; } = new HashSet<CountryLanguage>();
        public ICollection<Country> Countries { get; set; } = new HashSet<Country>();
    }
}
