using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Dto.Roles
{
    public class UpdateRoleDto : AddRoleDto
    {
        public int Id { get; set; }
    }
}
