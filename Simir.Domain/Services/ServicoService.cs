using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Domain.Services
{
    public class ServicoService : ServiceBase<TBServico>,
        IServicoService
    {
        private new readonly IServicoRepository _repository;

        public ServicoService(IServicoRepository repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
