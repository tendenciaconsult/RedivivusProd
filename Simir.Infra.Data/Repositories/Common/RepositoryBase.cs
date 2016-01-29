using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Simir.Domain.Helpers;
using Simir.Domain.Interfaces.Repository;
using Simir.Infra.Data.Context;

namespace Simir.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly IDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager<SimirContext>>()
                as ContextManager<SimirContext>;

            _dbContext = contextManager.GetContext();
            _dbSet = _dbContext.Set<TEntity>();
        }

        protected IDbContext Context
        {
            get { return _dbContext; }
        }

        protected DbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();

        }

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Update(TEntity obj)
        {
            var entry = Context.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public void RemoveRanger(IEnumerable<TEntity> List)
        {
            DbSet.RemoveRange(List);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> FindFirtAsync(Expression<Func<TEntity, bool>> predicate)
        {
            
            var retorno = DbSet.Where(predicate).FirstOrDefault();

            return retorno;
        }


        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }

        #endregion
    }


    public class RepositoryBase<TEntity, TEntity_Historico> : RepositoryBase<TEntity>
        where TEntity : class
        where TEntity_Historico : Historico<TEntity>, new()
    {
        private readonly DbSet<TEntity_Historico> _dbSet_Historico;

        public RepositoryBase()
        {
            _dbSet_Historico = Context.Set<TEntity_Historico>();
        }

        public void UpdateHistorico(string userId, DateTime dtMudanca, TEntity obj)
        {
            var entry = Context.Entry(obj);
            var pre_his = new TEntity_Historico();
            pre_his.To(obj);
            pre_his.UserId = userId;
            pre_his.dtAlteracao = dtMudanca;

            _dbSet_Historico.Add(pre_his);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public void AddHistorico(string userId, DateTime dtMudanca, TEntity obj)
        {
            DbSet.Add(obj);
            Context.SaveChanges();

            var entry = Context.Entry(obj);
            var pre_his = new TEntity_Historico();
            pre_his.To(obj);
            pre_his.UserId = userId;
            pre_his.dtAlteracao = dtMudanca;

            _dbSet_Historico.Add(pre_his);
        }

        public async Task AddComHistoricoAsync(string userId, DateTime dtMudanca, TEntity obj)
        {
            DbSet.Add(obj);
            await Context.SaveChangesAsync();
            


            var entry = Context.Entry(obj);
            var pre_his = new TEntity_Historico();
            pre_his.To(obj);
            pre_his.UserId = userId;
            pre_his.dtAlteracao = dtMudanca;

            _dbSet_Historico.Add(pre_his);
        }
    }

    public class RepositoryBaseDaPrefeitura<TEntity, TEntity_Historico> : RepositoryBase<TEntity>,
        IRepositoryBaseDaPrefeitura<TEntity, TEntity_Historico>
        where TEntity : DaPrefeitura
        where TEntity_Historico : Historico<TEntity>, new()
    {
        private readonly DbSet<TEntity_Historico> _dbSet_Historico;

        public RepositoryBaseDaPrefeitura()
        {
            _dbSet_Historico = Context.Set<TEntity_Historico>();
        }

        public IEnumerable<TEntity> GetAllByPrefeitura(int prefeituraID)
        {
            return DbSet.Where(x => x.PrefeituraID == prefeituraID && x.bAtivo);
        }

        public void UpdateComHistorico(string userId, DateTime dtMudanca, TEntity obj)
        {
            var entry = Context.Entry(obj);
            var pre_his = new TEntity_Historico();
            pre_his.To(obj);
            pre_his.UserId = userId;
            pre_his.dtAlteracao = dtMudanca;

            _dbSet_Historico.Add(pre_his);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public void AddComHistorico(int prefeituraID, string userId, DateTime dtMudanca, TEntity obj)
        {
            obj.PrefeituraID = prefeituraID;
            obj.bAtivo = true;
            DbSet.Add(obj);

            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb, ex
                    ); // Add the original exception as the innerException
            }

            var entry = Context.Entry(obj);
            var pre_his = new TEntity_Historico();
            pre_his.To(obj);
            pre_his.UserId = userId;
            pre_his.dtAlteracao = dtMudanca;

            _dbSet_Historico.Add(pre_his);
        }

        public void DeletarComHistorico(string userId, DateTime dtMudanca, TEntity obj)
        {
            obj.bAtivo = false;
            var entry = Context.Entry(obj);
            var pre_his = new TEntity_Historico();
            pre_his.To(obj);
            pre_his.UserId = userId;
            pre_his.dtAlteracao = dtMudanca;

            _dbSet_Historico.Add(pre_his);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public async Task<IEnumerable<TEntity>> GetAllByPrefeituraAsync(int prefeituraID)
        {
            return await DbSet.Where(x => x.PrefeituraID == prefeituraID && x.bAtivo).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int prefeituraID, int id)
        {
            var retorno = await GetByIdAsync(id);
            if (prefeituraID != (int) retorno.PrefeituraID)
            {
                throw new Exception("Prefeitura não autorizado");
            }
            if (!retorno.bAtivo)
            {
                throw new Exception("Usuario já não existe mais no sistema");
            }
            return retorno;
        }

        public async Task AddComHistoricoAsync(int prefeituraID, string userId, DateTime dtMudanca, TEntity obj)
        {
            DbSet.Add(obj);
            await Context.SaveChangesAsync();
            var entry = Context.Entry(obj);
            var pre_his = new TEntity_Historico();
            pre_his.To(obj);
            pre_his.UserId = userId;
            pre_his.dtAlteracao = dtMudanca;

            _dbSet_Historico.Add(pre_his);
        }

        public TEntity GetById(int prefeituraID, int id)
        {
            var retorno = GetById(id);
            if (prefeituraID != (int) retorno.PrefeituraID)
            {
                throw new Exception("Prefeitura não autorizado");
            }
            if (!retorno.bAtivo)
            {
                throw new Exception("Usuario já não existe mais no sistema");
            }
            return retorno;
        }
    }
}