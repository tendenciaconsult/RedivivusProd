using Simir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Domain.Interfaces.Services
{
    public interface IContratoFuncionarioService : IServiceBase<TBServicoFuncionario>
    {
        string[][] GetAllFuncaoTitulo();
        string[][] GetFuncaoTituloBySubtitulo(int id);
    }
}
