using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.Context
{
    public class BaseDbContext : IdentityDbContext<AspNetUser>, IDbContext
    {
        public BaseDbContext(string connectionStringName, int? currentUserId = null)
            : base(connectionStringName)
        {
            CurrentUserId = currentUserId;
        }

        public int? CurrentUserId { get; private set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}