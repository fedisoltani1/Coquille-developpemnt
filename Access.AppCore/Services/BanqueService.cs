using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistances;
using Access.AppCore.Interfaces.Persistence;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Access.AppCore.Services
{
    public class BanqueService(IRepository<Banque, int> banqueRepository,
           IUnitOfWork unitOfWork,
           IMapper mapper,
           ILogger<BanqueService> logger)
    {
    }
}
