using NationsApi.Application.Interfaces;

namespace NationsApi.API.Core
{
    public class FakeApiActor : IAppActor
    {
        public int Id => 1;

        public string Username => "fakeActor";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1,100);
    }
}
