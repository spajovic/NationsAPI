using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Domain
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public decimal Area { get; set; }
        public DateTime? NationalDay { get; set; }
        public string CountryCode { get; set; }
        public int RegionId { get; set; }
        public int UserId { get; set; }

        // Foreign key references
        public virtual Region Region { get; set; }
        public virtual User User { get; set; }

        // Collections
        public ICollection<CountryStat> CountryStats { get; set; } = new HashSet<CountryStat>();
        public ICollection<CountryLanguage> CountryLanguages { get; set; } = new HashSet<CountryLanguage>();
        public ICollection<CountryFlag> CountryFlags { get; set; } = new HashSet<CountryFlag>();
    }
}
