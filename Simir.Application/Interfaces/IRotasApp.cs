using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IRotasApp
    {
        object[][] GetRotasByPrefeitura(int prefeituraID);

        RotasVM GetProgramacaoByID(int? id, int prefeituraID);
        Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, RotasVM model);
        Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int p);
        List<ListaRotasVM> CarregaGrid(int PrefeituraID);

        object[][] DestinoResiduos();
    }
}