using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IEmpresaService : IServiceBase<TBEmpresa>
    {
        object[][] GetHashPorteEmpresa();
        object[][] GetHashRamoEmpresa();
        Task<bool> CriarNovaEmpresaAsync(TBEmpresa empresaNova);
        object[][] GetHashLicencaCadastrada(int empresaId);
        bool AddLicencaOperacional(int empresaId, TBLicencaOperacao lo);
        bool DeleteLicencaOperacional(int empresaId, int licenciaOperacionalId);
        bool EditarCadastro(TBEmpresa empresa);
        Task<TBLicencaOperacao> GetLicencaOperacional(int p, int licencaId);
        bool UpdateLicencaOperacional(int empresaId, TBLicencaOperacao lo);
        Task<TBEmpresa> GetByCnpjAsync(string cnpj);
    }
}