using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;

namespace Simir.Infra.Data.Repositories
{
    public class SecretariaRepository : RepositoryBase<TBSecretaria, TBSecretaria_Historico>, ISecretariaRepository
    {
    }
}