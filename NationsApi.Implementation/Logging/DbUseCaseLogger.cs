using NationsApi.Application.Interfaces;
using NationsApi.DataAccess;
using NationsApi.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Implementation.Logging
{
    public class DbUseCaseLogger : IUseCaseLogger
    {
        private readonly NationsContext _context;

        public DbUseCaseLogger(NationsContext context)
        {
            _context = context;
        }

        public void Log(IAppActor appActor, IUseCase useCase, object data)
        {
            _context.UseCaseLog.Add(new UseCaseLog
            {
                Actor = appActor.Username,
                Date = DateTime.Now,
                UseCaseName = useCase.Name,
                Data = JsonConvert.SerializeObject(data)

            });

            _context.SaveChanges();
        }
    }
}
