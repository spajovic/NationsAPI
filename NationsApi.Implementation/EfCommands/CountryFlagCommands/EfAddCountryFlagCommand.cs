using AutoMapper;
using NationsApi.Application.Commands.CountryFlags;
using NationsApi.DataAccess;
using NationsApi.Domain;

namespace NationsApi.Implementation.EfCommands.CountryFlagCommands
{
    public class EfAddCountryFlagCommand : BaseContext, IAddCountryFlagCommand
    {
        private IMapper _mapper;
        public EfAddCountryFlagCommand(NationsContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 39;

        public string Name => "Add country flag";

        public void Execute(CountryFlag request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}
