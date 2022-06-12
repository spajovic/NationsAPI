using NationsApi.Application.Interfaces;

namespace NationsApi.API.Core
{
    public class FakeAdminApiActor : IAppActor
    {
        public int Id => 1;

        public string Username => "fakeAdminActor";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1,100);
    }
}
