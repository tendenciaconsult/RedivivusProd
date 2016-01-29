using System.Collections.Generic;
using System.Web.Mvc;
using Simir.Application.ViewModels;

namespace Simir.Application.Interfaces
{
    public interface IPerfilApp
    {
        ICollection<ControllerVM> GetAllControllers();
        ControllerVM GetControllerByNome(string controllerNome);
        void UpdateController(ControllerVM controller);
        ICollection<ActionVM> GetAllAction();
        ActionVM GetActionByNome(string controllerNome, string actionNome);
        void UpdateAction(ActionVM model);
        ICollection<PerfilVM> GetAllPerfil();
        void UpdatePerfil(PerfilVM model, int[] actions);
        PerfilVM GetPerfilByNome(string perfilNome);
        MultiSelectList GetAllActionMS(string perfilNome);
        SelectList GetAllPerfilMS(int selecionados = 0);
        ModuloPaiVM GetModuloPaiById(int moduloId);
        MultiSelectList GetAllModulosMS();
        void UpdateModuloPai(ModuloPaiVM model, int[] simirModulosLB);
        MultiSelectList GetAllModulosRaizMS();
        MultiSelectList GetAllModulosMS(IEnumerable<int> selecionadosId);
    }
}