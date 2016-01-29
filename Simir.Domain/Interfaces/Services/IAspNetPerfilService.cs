using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;
namespace Simir.Domain.Interfaces.Services
{
    public interface IAspNetPerfilService : IServiceBase<AspNetPerfil>
    {
        bool UpdateController(string nome, string display);
        bool UpdateAction(string controller, string nome, string display);
        bool UpdatePerfil(string perfil, string descricao);
        bool AddActionToPerfil(int actionId, string p);
        bool AddActionToPerfil(string controller, string action, string perfil);
        bool AddModuloToPerfil(int moduloId, string p);
        IEnumerable<AspNetController> GetAllController();
        AspNetController GetControllerByNome(string controllerNome);
        IEnumerable<AspNetAction> GetAllAction();
        AspNetAction GetActionByNome(string controllerNome, string actionNome);
        AspNetPerfil GetPerfilByNome(string perfilNome);
        AspNetModuloPai GetModuloPaiById(int moduloId);
        ICollection<AspNetModulo> GetAllModulo();
        bool UpdateModuloPai(AspNetModuloPai pai);
        AspNetModulo GetModuloById(int item);
        ICollection<AspNetModulo> GetModulosRaiz();
        ICollection<AspNetModulo> GetAllModulosAnemico();

        Task<AspNetPerfil> GetPerfilByID(int p);

        List<AspNetPerfil> GetByPrefeituraID(int idPrefeitura);

        Task<bool> addPerfilAsync(AspNetUser user, AspNetPerfil Item);
        Task<bool> UpdatePerfilAsync(AspNetUser user, AspNetPerfil Item);
        Task<bool> ExcluirPerfilAsync(AspNetUser user, int idColetaEventual);
    }
}