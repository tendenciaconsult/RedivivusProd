using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;

namespace Simir.Infra.Data.Repositories
{
    public class SecretariaResponsabilidadesRepository :
        RepositoryBase<TBSecretariasResponsabilidade, TBSecretariasResponsabilidade_Historico>,
        ISecretariaResponsabilidadesRepository
    {
    }
}