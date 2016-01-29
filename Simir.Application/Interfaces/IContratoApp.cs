using Simir.Application.ViewModels.ContratoVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using System.Web.Mvc;

namespace Simir.Application.Interfaces
{
    public interface IContratoApp
    {
        ContratoVM GetContrato(int? id, int prefeituraID);
        Task<IDictionary<string, ModelState>> Salvar(AspNetUser user, ContratoVM model);
        Task<IDictionary<string, ModelState>> Excluir(AspNetUser user, int iD);
        string[][] GetAllFuncaoTitulo();
        string[][] GetFuncaoTituloBySubtitulo(int id);
    }
}
