using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        // Foreign key references
        public virtual Role Role { get; set; }

        // Collections
        public ICollection<Country> Countries { get; set; } = new HashSet<Country>();
    }
}
