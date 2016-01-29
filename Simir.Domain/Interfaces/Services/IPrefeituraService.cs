using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IPrefeituraService : IServiceBase<TBPrefeitura>
    {
        bool EditarPrefeitura(AspNetUser user, TBPrefeitura prefeitura);
    }
}