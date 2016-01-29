using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IDestinadorTratadoService : IServiceBase<TBResiduosTratado>
    {
        double GetRejeitosNaoTratados(int empresaID);
    }
}
