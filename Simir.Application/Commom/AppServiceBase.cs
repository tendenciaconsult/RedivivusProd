using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Simir.Application.Interfaces;
using Simir.Infra.Data.Context;

namespace Simir.Application
{
    public class AppServiceBase<TContext> : ITransactionAppService<TContext>
        where TContext : IDbContext, new()
    {
        private IUnitOfWork<TContext> _uow;

        public virtual void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork<TContext>>();


            _uow.BeginTransaction();
        }

        public virtual void Commit()
        {
            _uow.SaveChanges();
        }

        public virtual async Task CommitAsync()
        {
            await _uow.SaveChangesAsync();
        }
    }
}