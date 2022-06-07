using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Domain
{
    public class CountryLanguage
    {
        public int CountryId { get; set; }
        public int LanguageId { get; set; }

        // Foreign key references
        public virtual Language Language { get; set; }
        public virtual Country Country { get; set; }
    }
}
