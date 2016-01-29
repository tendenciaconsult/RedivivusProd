using System;
using System.Collections.Generic;
using System.Linq;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Simir.Domain.Services
{
    public class AspNetPerfilService : ServiceBase<AspNetPerfil>, IAspNetPerfilService
    {
        private readonly IAspNetActionRepository _simirActionRepository;
        private readonly IAspNetControllerRepository _simirControllerRepository;
        private readonly IAspNetModuloRepository _simirModuloRepository;
        private readonly IAspNetPerfilRepository _simirPerfilRepository;
        private readonly ILogEventoRepository _repositoryLog;

        public AspNetPerfilService(IAspNetPerfilRepository simirPerfilRepository,
            IAspNetControllerRepository simirControllerRepository,
            IAspNetActionRepository simirActionRepository,
            IAspNetModuloRepository simirModuloRepository,
            ILogEventoRepository repositoryLog)
            : base(simirPerfilRepository)
        {
            _simirPerfilRepository = simirPerfilRepository;
            _simirControllerRepository = simirControllerRepository;
            _simirActionRepository = simirActionRepository;
            _simirModuloRepository = simirModuloRepository;
            _repositoryLog = repositoryLog;
        }

        public bool UpdateController(string nome, string display)
        {
            var control = _simirControllerRepository.Find(x => x.Nome == nome).FirstOrDefault();
            if (control == null)
            {
                _simirControllerRepository.Add(new AspNetController {Nome = nome, Display = display});
            }
            else
            {
                if (control.Display == display)
                    return false;
                control.Display = display;
                _simirControllerRepository.Update(control);
            }
            return true;
        }

        public async Task<AspNetPerfil> GetPerfilByID(int id)
        {
            return _simirPerfilRepository.Get(x => x.AspNetPerfilId == id).FirstOrDefault();
        }

        public bool UpdateAction(string controllerNome, string actionNome, string display)
        {
            var control = _simirControllerRepository.Find(x => x.Nome == controllerNome).FirstOrDefault();
            if (control == null)
            {
                throw new ArgumentException("controller");
            }
            var action = GetActionByNome(controllerNome, actionNome);
            if (action == null)
                _simirActionRepository.Add(new AspNetAction
                {
                    Nome = actionNome,
                    Display = display,
                    AspNetControllerId = control.AspNetControllerId
                });
            else
            {
                if (action.Display == display)
                    return false;
                action.Display = display;
                _simirActionRepository.Update(action);
            }
            return true;
        }

        public bool UpdatePerfil(string perfilNome, string descricao)
        {
            var perfil = _simirPerfilRepository.Find(x => x.Nome == perfilNome).FirstOrDefault();
            if (perfil == null)
            {
                _simirPerfilRepository.Add(new AspNetPerfil {Nome = perfilNome, Descricao = descricao});
            }
            else
            {
                if (perfil.Descricao == descricao)
                    return false;
                perfil.Descricao = descricao;
                _simirPerfilRepository.Update(perfil);
            }
            return true;
        }

        public bool AddActionToPerfil(string controllerNome, string actionNome, string perfilNome)
        {
            var action = GetActionByNome(controllerNome, actionNome);
            if (action == null) throw new ArgumentException("controller ou action");

            return AddModuloToPerfil(action, perfilNome);
        }

        public bool AddModuloToPerfil(int moduloId, string perfilNome)
        {
            var modulo = _simirModuloRepository.GetById(moduloId);
            if (modulo == null) throw new ArgumentException("actionId");

            return AddModuloToPerfil(modulo, perfilNome);
        }

        public bool AddActionToPerfil(int actionId, string perfilNome)
        {
            var action = _simirActionRepository.GetById(actionId);
            if (action == null) throw new ArgumentException("actionId");

            return AddModuloToPerfil(action, perfilNome);
        }

        public IEnumerable<AspNetController> GetAllController()
        {
            return _simirControllerRepository.GetAll();
        }

        public AspNetController GetControllerByNome(string controllerNome)
        {
            return _simirControllerRepository.Find(x => x.Nome == controllerNome).FirstOrDefault();
        }

        public IEnumerable<AspNetAction> GetAllAction()
        {
            return _simirActionRepository.GetAll();
        }

        public AspNetAction GetActionByNome(string controllerNome, string actionNome)
        {
            return
                _simirActionRepository.Find(x => x.Nome == actionNome && x.AspNetController.Nome == controllerNome)
                    .FirstOrDefault();
        }

        public AspNetPerfil GetPerfilByNome(string perfilNome)
        {
            return _simirPerfilRepository.Find(x => x.Nome == perfilNome).FirstOrDefault();
        }

        public AspNetModuloPai GetModuloPaiById(int moduloId)
        {
            var mod = _simirModuloRepository.Find(x => x.AspNetModuloId == moduloId).FirstOrDefault();
            if (mod == null || !(mod is AspNetModuloPai)) return null;
            return mod as AspNetModuloPai;
        }

        public ICollection<AspNetModulo> GetAllModulo()
        {
            return _simirModuloRepository.GetAll().ToList();
        }

        public bool UpdateModuloPai(AspNetModuloPai pai)
        {
            var old = GetModuloPaiById(pai.AspNetModuloId);
            if (old == null)
            {
                if (pai.ModuloFilhos.Where(x => x.Nivel > 0).Count() > 0)
                    throw new Exception("Você adicionou algum modulo que já é sub-nível de outro");
                pai.DescerUmNivel();
                _simirModuloRepository.Add(pai);
            }
            else
            {
                //if (pai.ModuloFilhos.Where(x => x.Nivel > 0).Count() > 0) throw new Exception("Você adicionou algum modulo que já é sub-nível de outro");
                var adicionar = pai.ModuloFilhos.Where(x => x.Nivel == 0).ToList();
                var jatem = pai.ModuloFilhos.Where(x => x.Nivel == 1);
                var remover = new List<AspNetModulo>();

                foreach (var item in old.ModuloFilhos)
                {
                    if (jatem.Where(x => x.AspNetModuloId == item.AspNetModuloId).FirstOrDefault() == null)
                    {
                        remover.Add(item);
                        item.Nivel--;
                        if (item is AspNetModuloPai)
                            (item as AspNetModuloPai).SobeUmNivel();
                        _simirModuloRepository.Update(item);
                    }
                }
                if (remover.Count == 0 && adicionar.Count == 0) return false;
                foreach (var item in remover)
                {
                    old.ModuloFilhos.Remove(item);
                }

                foreach (var item in adicionar)
                {
                    if (item is AspNetModuloPai)
                        (item as AspNetModuloPai).DescerUmNivel();
                    old.ModuloFilhos.Add(item);
                }

                _simirModuloRepository.Update(old);
            }
            return true;
        }

        public AspNetModulo GetModuloById(int id)
        {
            return _simirModuloRepository.Find(x => x.AspNetModuloId == id).FirstOrDefault();
        }

        public ICollection<AspNetModulo> GetModulosRaiz()
        {
            return _simirModuloRepository.Find(x => x.Nivel == 0).ToList();
        }

        public ICollection<AspNetModulo> GetAllModulosAnemico()
        {
            var raizes = _simirModuloRepository.Find(x => x.Nivel == 0).ToList();
            var retorno = new List<AspNetModulo>();
            foreach (var item in raizes)
            {
                retorno.AddRange(item.ToListAnemica());
            }
            return retorno;
        }

        private bool AddModuloToPerfil(AspNetModulo modulo, string perfilNome)
        {
            var perfil = _simirPerfilRepository.Find(x => x.Nome == perfilNome).FirstOrDefault();
            if (perfil == null) throw new ArgumentException("perfilNome");

            perfil.SimirModulos = perfil.SimirModulos == null ? new List<AspNetModulo>() : perfil.SimirModulos;

            if (perfil.SimirModulos.Contains(modulo))
                return false;
            perfil.SimirModulos.Add(modulo);
            return true;
        }
        public List<AspNetPerfil> GetByPrefeituraID(int PrefeituraID)
        {
            return _simirPerfilRepository.Get
                (
                    x => x.PrefeituraID == PrefeituraID
                         && x.bAtivo == true
                )
                .OrderBy(x => x.Nome).ToList();
        }

        public async Task<bool> addPerfilAsync(AspNetUser user, AspNetPerfil Dados)
        {
            var dt = DateTime.Now;

            _simirPerfilRepository.Add(Dados);
            //Add(Programação de Limpeza Ordinaria);

            var log = TBLogEvento.Novo(user, dt, "Adicionou um novo Perfil");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> UpdatePerfilAsync(AspNetUser user, AspNetPerfil Dados)
        {
            var dt = DateTime.Now;

            _simirPerfilRepository.Update(Dados);


            var log = TBLogEvento.Novo(user, dt, "Editou um Perfil");
            _repositoryLog.Add(log);

            return true;
        }

        public async Task<bool> ExcluirPerfilAsync(AspNetUser user, int id)
        {
            var dt = DateTime.Now;

            var Dados = _simirPerfilRepository.GetById(id);

            Dados.bAtivo = false;

            _simirPerfilRepository.Update(Dados);


            var log = TBLogEvento.Novo(user, dt, "Desativou um Perfil");
            _repositoryLog.Add(log);

            return true;
        }
    }
}