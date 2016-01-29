namespace Simir.Domain.Interfaces.ServiceAgents
{
    public interface ISvcConsultCepApi
    {
        bool CepUnico { get; }
        string Logradouro { get; }
        bool Encontrou { get; }
        string Uf { get; }
        string Municipio { get; }
        string Bairro { get; }
        void BuscaCep(string cep);
    }
}