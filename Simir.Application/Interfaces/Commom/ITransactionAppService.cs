using System.Threading.Tasks;
using Simir.Infra.Data.Context;

namespace Simir.Application.Interfaces
{
    public interface ITransactionAppService<TContext>
        where TContext : IDbContext, new()
    {
        void BeginTransaction();
        void Commit();
        Task CommitAsync();
    }
}