using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private int id;
        private string entityName;

        public EntityNotFoundException(int id, string entityName)
        {
            this.id = id;
            this.entityName = entityName;
        }

        public override string Message => "Entity with an id of " + id + " does not exist in entity " + entityName;
    }
}
