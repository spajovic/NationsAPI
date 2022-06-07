using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Domain
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        // Collections
        public ICollection<User> Users { get; set; } = new HashSet<User>();
        public ICollection<RoleUseCase> RoleUseCases { get; set; } = new HashSet<RoleUseCase>();
    }
}
