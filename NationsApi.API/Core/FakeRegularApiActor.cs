using NationsApi.Application.Interfaces;

namespace NationsApi.API.Core
{
    public class FakeRegularApiActor : IAppActor
    {
        public int Id => 2;

        public string Username => "fakeRegularActor";

        public IEnumerable<int> AllowedUseCases => new List<int>() { 4, 5, 9, 10, 14, 15, 19, 20, 24, 25, 29, 30 };
    }
}
