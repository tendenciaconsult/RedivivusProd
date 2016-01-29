using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Simir.Domain.Helpers;

namespace Simir.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void RemoveRanger(IEnumerable<TEntity> List);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindFirtAsync(Expression<Func<TEntity, bool>> predicate);
    }

    public interface IRepositoryBase<TEntity, TEntity_Historico> : IRepositoryBase<TEntity>
        where TEntity : class
        where TEntity_Historico : Historico<TEntity>, new()
    {
        void UpdateHistorico(string userId, DateTime dtMudanca, TEntity obj);
        void AddHistorico(string userId, DateTime dtMudanca, TEntity obj);
        Task AddComHistoricoAsync(string userId, DateTime dtMudanca, TEntity obj);
    }

    public interface IRepositoryBaseDaPrefeitura<TEntity, TEntity_Historico> : IRepositoryBase<TEntity>
        where TEntity : DaPrefeitura
        where TEntity_Historico : Historico<TEntity>, new()
    {
        IEnumerable<TEntity> GetAllByPrefeitura(int prefeituraID);
        TEntity GetById(int prefeituraID, int id);
        void UpdateComHistorico(string userId, DateTime dtMudanca, TEntity obj);
        void AddComHistorico(int prefeituraID, string userId, DateTime dtMudanca, TEntity obj);
        void DeletarComHistorico(string userId, DateTime dtMudanca, TEntity obj);
        Task<IEnumerable<TEntity>> GetAllByPrefeituraAsync(int prefeituraID);
        Task<TEntity> GetByIdAsync(int prefeituraID, int id);
        Task AddComHistoricoAsync(int prefeituraID, string userId, DateTime dtMudanca, TEntity obj);
    }
}