
using Access.AppCore.Interfaces.Persistances;
using Console = Access.AppCore.Entities.Console;

namespace Access.AppCore.Interfaces.Persistence.Repositories
{
    public interface IConsoleRepository : IRepository<Console, int>
    {
    }
}
