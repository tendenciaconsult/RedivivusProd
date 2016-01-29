using System.Threading.Tasks;

namespace Simir.Infra.Data.Context
{
    public interface IUnitOfWork<TContext>
        where TContext : IDbContext, new()
    {
        void BeginTransaction();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}