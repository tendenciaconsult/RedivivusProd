using Simir.Domain.Interfaces.Repository;

namespace Simir.Infra.Data.Context
{
    public class RepositoryContext : IRepositoryContext
    {
        private SimirContext context;

        public void BeginTransaction()
        {
        }

        public void SaveChanges()
        {
        }

        public void Dispose()
        {
        }
    }
}