using Simir.Application.ViewModels;

namespace Simir.Application.Interfaces
{
    public interface IEnderecoApp
    {
        object[][] GetUfs();
        object[][] GetMunicipiosByUf(int p);
        object[][] GetBairrosByMunicipio(int p);
        object[][] GetLogradouroByBairro(int p);
        EnderecoVM ConsultaCep(string id);
    }
}