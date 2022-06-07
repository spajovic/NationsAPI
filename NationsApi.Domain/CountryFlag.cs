using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Domain
{
    public class CountryFlag : BaseEntity
    {
        public string? FilePath { get; set; }
        public int CountryId { get; set; }

        // Foreign key references
        public virtual Country Country { get; set; }
    }
}
