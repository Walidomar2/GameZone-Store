using Gamezone.ViewModels;

namespace Gamezone.Interfaces
{
    public interface IGamesRepository
    {
        public Task Create(CreateGameFormVM gameModel);
    }
}
