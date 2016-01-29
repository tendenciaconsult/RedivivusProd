using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IEmpresaApp
    {
        object[][] GetHashPorteEmpresa();
        object[][] GetHashRamoEmpresa();
        object[][] GetHashLicencaCadastrada(int? nullable);
        Task<IDictionary<string, ModelState>> NovoCadastroAsync(ApplicationUserManager UserManager, EmpresaNovaVM model);

        Task<IDictionary<string, ModelState>> AddLicencaOperacional(TBEmpresa tBEmpresa,
            LicencaOperacionalVM licenciaOperacional);

        Task<IDictionary<string, ModelState>> DeleteLicencaOperacional(TBEmpresa tBEmpresa, int licenciaOperacionalId);
        Task<IDictionary<string, ModelState>> EditarCadastroAsync(TBEmpresa tBEmpresa, DadosCadastraisVM model);
        Task<LicencaOperacionalVM> GetLicencaOperacional(TBEmpresa tBEmpresa, int id);

        Task<IDictionary<string, ModelState>> SalvarLicencaOperacional(TBEmpresa tBEmpresa,
            LicencaOperacionalVM licenciaOperacional);

        Task<EmpresaBuscaVM> GetEmpresaByCnpjAsync(string cnpj);
    }
}