using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simir.Domain.Entities;
using Simir.Domain.Helpers;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class EmpresaService : ServiceBase<TBEmpresa>, IEmpresaService
    {
        private readonly ILicencaOperacaoRepository _licencaOperacaoRepository;
        private readonly IPorteEmpresaRepository _porteEmpresaRepository;
        private readonly IRamoEmpresaRepository _ramoEmpresaRepository;
        private new readonly IEmpresaRepository _repository;

        public EmpresaService(IEmpresaRepository repository,
            IPorteEmpresaRepository porteEmpresaRepository,
            IRamoEmpresaRepository ramoEmpresaRepository,
            ILicencaOperacaoRepository licencaOperacaoRepository
            )
            : base(repository)
        {
            _repository = repository;
            _porteEmpresaRepository = porteEmpresaRepository;
            _ramoEmpresaRepository = ramoEmpresaRepository;
            _licencaOperacaoRepository = licencaOperacaoRepository;
        }

        public object[][] GetHashPorteEmpresa()
        {
            return
                _porteEmpresaRepository.GetAll()
                    .Select(x => new object[] {x.PorteEmpresaID, x.nmPorteEmpresa})
                    .ToArray();
        }

        public object[][] GetHashRamoEmpresa()
        {
            return
                _ramoEmpresaRepository.GetAll().Select(x => new object[] {x.RamoEmpresaID, x.nmRamoEmpresa}).ToArray();
        }

        public async Task<bool> CriarNovaEmpresaAsync(TBEmpresa empresaNova)
        {
            var valido = empresaNova.Validar();
            var emp = await _repository.FindFirtAsync(x => x.CNPJ == empresaNova.CNPJ);
            if (emp != null)
            {
                throw new ArgumentException(MensagensErro.cnpjJaCadastrado, "CNPJ");
            }

            emp = await _repository.FindFirtAsync(x => x.Email == empresaNova.Email);
            if (emp != null)
            {
                throw new ArgumentException(MensagensErro.emailJaCadastrado, "Email");
            }

            if (valido)
                _repository.Add(empresaNova);

            return valido;
        }

        public bool EditarCadastro(TBEmpresa empresa)
        {
            var valido = empresa.Validar();
            if (valido)
                _repository.Update(empresa);

            return valido;
        }

        public object[][] GetHashLicencaCadastrada(int empresaId)
        {
            var ddd =
                _licencaOperacaoRepository.Get(x => x.EmpresaID == empresaId)
                    .Select(x => new object[] {x.LicencaOperacaoID, x.ToString()});


            var fff = new List<object[]>();
            fff.Add(new object[] {"-1", "Selecione para editar..."});
            fff.AddRange(ddd);
            return fff.ToArray();
        }

        public bool AddLicencaOperacional(int empresaId, TBLicencaOperacao lo)
        {
            var empresa = _repository.GetById(empresaId);
            lo.Valida();
            empresa.TBLicencaOperacaos.Add(lo);
            return true;
        }

        public bool UpdateLicencaOperacional(int empresaId, TBLicencaOperacao lo)
        {
            var empresa = _repository.GetById(empresaId);
            var lin = empresa.TBLicencaOperacaos.FirstOrDefault(x => x.LicencaOperacaoID == lo.LicencaOperacaoID);
            if (lin == null)
                throw new Exception("Esta licença operacional não pertence a esta empresa.");

            lin.nmLicencaOperacao = lo.nmLicencaOperacao;
            lin.dtValidade = lo.dtValidade;
            lin.CodigoLicencaOperacao = lo.CodigoLicencaOperacao;
            lin.nmLicencaOperacao = lo.nmLicencaOperacao;
            _licencaOperacaoRepository.Update(lin);
            return true;
        }

        public bool DeleteLicencaOperacional(int empresaId, int licenciaOperacionalId)
        {
            var empresa = _repository.GetById(empresaId);

            var licenciaOperaciona =
                empresa.TBLicencaOperacaos.FirstOrDefault(x => x.LicencaOperacaoID == licenciaOperacionalId);

            empresa.TBLicencaOperacaos.Remove(licenciaOperaciona);
            return true;
        }

        public async Task<TBLicencaOperacao> GetLicencaOperacional(int empresaId, int licencaId)
        {
            return
                await
                    _licencaOperacaoRepository.FindFirtAsync(
                        x => x.EmpresaID == empresaId && x.LicencaOperacaoID == licencaId);
        }

        public async Task<TBEmpresa> GetByCnpjAsync(string cnpj)
        {
            if (Help.CnpjValido(cnpj))
            {
                return await _repository.FindFirtAsync(x => x.CNPJ == cnpj);
            }
            throw new ArgumentException(MensagensErro.cnpjInvalido, "Cnpj");
        }
    }
}