using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IEnderecoService : IServiceBase<TBEndereco>
    {
        object[][] GetUfs();
        object[][] GetMunicipiosByUf(int idUf);
        object[][] GetBairrosByMunicipio(int idMunicipio);
        TBEnderecoLogradouro ConsultaCep(string cep);
        bool ValidaEndereco(TBEndereco tBEndereco);
        object[][] GetLogradouroByBairro(int idBairro);
    }
}