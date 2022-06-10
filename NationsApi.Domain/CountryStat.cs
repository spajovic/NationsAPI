using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Domain
{
    public class CountryStat
    {
        public int Year { get; set; }
        public int CountryId { get; set; }
        public int? Population { get; set; }
        public decimal? Gdp { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Foreign key references
        public virtual Country Country { get; set; }

    }
}
