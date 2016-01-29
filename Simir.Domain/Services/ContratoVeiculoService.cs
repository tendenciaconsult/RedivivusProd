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
    public class ContratoVeiculoService : ServiceBase<TBContratoVeiculo>,
        IContratoVeiculoService
    {
        private new readonly IContratoVeiculoRepository _repository;

        public ContratoVeiculoService(IContratoVeiculoRepository repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
