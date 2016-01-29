using System.Collections.Generic;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        protected IRepositoryBase<TEntity> Repository
        {
            get { return _repository; }
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }
    }

    /*
    public class ServiceBaseDaPrefeitura<TEntity> : IServiceBase<TEntity> where TEntity : DaPrefeitura
    {
        protected readonly IRepositoryBaseDaPrefeitura<TEntity, TEntity_Historico> _repository;

        public ServiceBaseDaPrefeitura(IRepositoryBase<TEntity, TEntity_Historico> repository)
        {
            _repository = repository;
        }

        protected IRepositoryBase<TEntity> Repository
        {
            get { return _repository; }
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {

            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public IEnumerable<TEntity> GetAllByPrefeitura(int prefeituraID)
        {
            return _repository.GetAllByPrefeitura(prefeituraID);
        }

    }*/
}