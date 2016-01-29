using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IDestinadorService : IServiceBase<TBResiduosDestinadore>
    {
        IList<TBResiduosDestinadore> GetResiduosGeradosByEmpresaID(int empresaID);

        bool Remove(TBResiduosDestinadoreItem itemModel);

        object[][] HashResiduosRecebidoNaoTratados(int empresaId);
    }
}
