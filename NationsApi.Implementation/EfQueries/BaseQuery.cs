using NationsApi.Application.Searches;
using NationsApi.Application.Extensions;
using NationsApi.DataAccess;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NationsApi.Implementation.EfQueries
{
    public abstract class BaseQuery<T> where T : BaseEntity
    {
        
        protected NationsContext context { get; }

        protected BaseQuery(NationsContext context)
        {
            this.context = context;
        }

        protected void BasicFilter(ref IQueryable<T> query, BaseSearch search)
        {
            if(search.OnlyActive == true)
            {
                query = query.Where(x => x.DeletedAt == null);
            }

            query = query.SkipItems(search.Page, search.ItemsPerPage);
        }

    }
}
