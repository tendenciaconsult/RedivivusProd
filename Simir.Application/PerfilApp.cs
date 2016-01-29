using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;

namespace Simir.Application
{
    public class PerfilApp : AppServiceBase<SimirContext>, IPerfilApp
    {
        private readonly IAspNetPerfilService _simirPerfilService;

        public PerfilApp(
            IAspNetPerfilService simirPerfilService
            )
        {
            _simirPerfilService = simirPerfilService;
        }

        public ICollection<ControllerVM> GetAllControllers()
        {
            var controllers = _simirPerfilService.GetAllController();

            var controllersVM = new List<ControllerVM>();
            foreach (var item in controllers)
            {
                controllersVM.Add(ControllerVM.ToDomain(item));
            }

            return controllersVM;
        }

        public ControllerVM GetControllerByNome(string controllerNome)
        {
            var controller = _simirPerfilService.GetControllerByNome(controllerNome);
            if (controller == null)
                return new ControllerVM {ControllerNome = controllerNome, Display = ""};
            return ControllerVM.ToDomain(controller);
        }

        public void UpdateController(ControllerVM controllerVM)
        {
            BeginTransaction();
            if (_simirPerfilService.UpdateController(controllerVM.ControllerNome, controllerVM.Display)) Commit();
        }

        public ICollection<ActionVM> GetAllAction()
        {
            var actions = _simirPerfilService.GetAllAction();

            var actionsVM = new List<ActionVM>();
            foreach (var item in actions)
            {
                actionsVM.Add(ActionVM.ToDomain(item));
            }

            return actionsVM;
        }

        public ActionVM GetActionByNome(string controllerNome, string actionNome)
        {
            var action = _simirPerfilService.GetActionByNome(controllerNome, actionNome);
            if (action == null)
                return new ActionVM {ControllerNome = controllerNome, Display = ""};
            return ActionVM.ToDomain(action);
        }

        public void UpdateAction(ActionVM model)
        {
            BeginTransaction();
            if (_simirPerfilService.UpdateAction(model.ControllerNome, model.ActionNome, model.Display)) Commit();
        }

        public ICollection<PerfilVM> GetAllPerfil()
        {
            var perfis = _simirPerfilService.GetAll();

            var perfisVM = new List<PerfilVM>();
            foreach (var item in perfis)
            {
                perfisVM.Add(PerfilVM.ToDomain(item));
            }

            return perfisVM;
        }

        public void UpdatePerfil(PerfilVM model, int[] modulosId)
        {
            BeginTransaction();
            if (_simirPerfilService.UpdatePerfil(model.Nome, model.Descricao)) Commit();

            foreach (var item in modulosId)
            {
                if (_simirPerfilService.AddModuloToPerfil(item, model.Nome)) Commit();
            }
        }

        public PerfilVM GetPerfilByNome(string perfilNome)
        {
            var perfil = _simirPerfilService.GetPerfilByNome(perfilNome);
            if (perfil == null)
                return new PerfilVM {SimirPerfilId = 0, Nome = "", Descricao = "", SimirModulos = new List<ModuloVM>()};
            return PerfilVM.ToDomain(perfil);
        }

        public MultiSelectList GetAllActionMS(string perfilNome)
        {
            var actions = _simirPerfilService.GetAllAction().ToDictionary(k => k.AspNetModuloId, v => v.GetUrl());
            var perfil = _simirPerfilService.GetPerfilByNome(perfilNome);
            if (perfil == null)
                return new MultiSelectList(actions, "Key", "Value");
            return new MultiSelectList(actions, "Key", "Value", perfil.SimirModulos.Select(x => x.AspNetModuloId));
        }

        public SelectList GetAllPerfilMS(int selecionados = 0)
        {
            var perfis = _simirPerfilService.GetAll().ToDictionary(k => k.AspNetPerfilId, v => v.Nome);

            if (selecionados == 0)
                return new SelectList(perfis, "Key", "Value");
            return new SelectList(perfis, "Key", "Value", selecionados);
        }

        public ModuloPaiVM GetModuloPaiById(int moduloId)
        {
            var modulo = _simirPerfilService.GetModuloPaiById(moduloId);
            if (modulo == null)
                return ModuloPaiVM.ToDomain(new AspNetModuloPai());
            return ModuloPaiVM.ToDomain(modulo);
        }

        public void UpdateModuloPai(ModuloPaiVM model, int[] simirModulosLB)
        {
            BeginTransaction();
            var modulosFilho = new List<AspNetModulo>();

            foreach (var item in simirModulosLB)
            {
                var filho = _simirPerfilService.GetModuloById(item);
                if (filho != null) modulosFilho.Add(filho);
            }
            var pai = new AspNetModuloPai
            {
                AspNetModuloId = model.ModuloId,
                Display = model.Display,
                ModuloFilhos = modulosFilho
            };
            if (_simirPerfilService.UpdateModuloPai(pai)) Commit();
        }

        public MultiSelectList GetAllModulosMS()
        {
            var modulos = _simirPerfilService.GetAllModulosAnemico();
            var modulosVM = ModuloVM.ToDomain(modulos);
            var modulosVMHash = modulosVM.ToDictionary(k => k.ModuloId, v => v.DisplayToListbox);

            return new MultiSelectList(modulosVMHash, "Key", "Value");
        }

        public MultiSelectList GetAllModulosRaizMS()
        {
            var modulos = _simirPerfilService.GetModulosRaiz();
            var modulosVM = ModuloVM.ToDomain(modulos);
            var modulosVMHash = modulosVM.ToDictionary(k => k.ModuloId, v => v.DisplayToListbox);

            return new MultiSelectList(modulosVMHash, "Key", "Value");
        }

        public MultiSelectList GetAllModulosMS(IEnumerable<int> selecionadosId)
        {
            var modulos = _simirPerfilService.GetAllModulosAnemico();
            var modulosVM = ModuloVM.ToDomain(modulos);
            var modulosVMHash = modulosVM.ToDictionary(k => k.ModuloId, v => v.DisplayToListbox);

            return new MultiSelectList(modulosVMHash, "Key", "Value", selecionadosId);
        }

        public void UpdatePerfil(PerfilVM model)
        {
            BeginTransaction();
            if (_simirPerfilService.UpdatePerfil(model.Nome, model.Descricao)) Commit();

            foreach (var item in model.SimirModulos)
            {
                if (_simirPerfilService.AddModuloToPerfil(item.ModuloId, model.Nome)) Commit();
                //if (_simirPerfilService.AddActionToPerfil(item.ControllerNome, item.ActionNome, model.Nome)) Commit();
            }
        }
    }
}