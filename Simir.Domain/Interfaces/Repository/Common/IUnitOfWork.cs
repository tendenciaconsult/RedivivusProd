using System;

namespace Simir.Domain.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void SaveChanges();
    }
}