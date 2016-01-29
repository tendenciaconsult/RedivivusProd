using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;


namespace Simir.Domain.Services
{
    public class FaleConoscoService : ServiceBase<TBFaleConosco>, IFaleConoscoService
    {
        private new readonly IFaleConoscoRepository _repository;

        public FaleConoscoService(IFaleConoscoRepository repository
            )
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> Add(TBFaleConosco item)
        {
            var dt = DateTime.Now;

            _repository.Add(item);

            return true;
        }

    }
}
