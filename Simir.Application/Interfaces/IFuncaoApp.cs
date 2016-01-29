using System.Collections.Generic;
using System.Web.Mvc;
using Simir.Application.ViewModels;

namespace Simir.Application.Interfaces
{
    public interface IFuncaoApp
    {
        ICollection<FuncaoVM> GetAllFuncao();
        FuncaoVM GetFuncaoByNome(string funcaoNome);
        void UpdateFuncao(FuncaoVM model, int SimirPerfilLB);
        MultiSelectList GetAllFuncaoMS(int[] selecionados);
    }
}