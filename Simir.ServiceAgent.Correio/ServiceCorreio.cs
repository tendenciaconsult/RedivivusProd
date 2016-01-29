using System;
using Correios.Net;
using Simir.Domain.Interfaces.ServiceAgents;

namespace Simir.ServiceAgent.Correio
{
    public class ServiceCorreio : ISvcConsultCepApi, IDisposable
    {
        private Address address;

        public void Dispose()
        {
        }

        public string Logradouro { get; private set; }
        public string Municipio { get; private set; }
        public string Bairro { get; private set; }
        public bool CepUnico { get; private set; }
        public bool Encontrou { get; private set; }
        public string Uf { get; private set; }

        public void BuscaCep(string cep)
        {
            address = SearchZip.GetAddress(cep);

            if (address.Street != "Não encontrado")
            {
                Encontrou = true;
                Logradouro = address.Street;
                Uf = address.State;
                Municipio = address.City;
                Bairro = address.District;
                CepUnico = address.UniqueZip;
            }
            else
            {
                Encontrou = false;
                Logradouro = "";
                Uf = "";
                Municipio = "";
                Bairro = "";
                CepUnico = true;
            }
        }

        public override string ToString()
        {
            return address.Street + address.District + address.UniqueZip + address.Zip + address.State + address.City;
        }
    }
}