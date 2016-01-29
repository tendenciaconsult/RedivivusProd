using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using Simir.Domain;
using Simir.Domain.Entities;
using Simir.Domain.Enuns;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;
using Simir.Application.Helpers;

namespace Simir.Application
{
    public class EmpresaApp : AppServiceBase<SimirContext>, IEmpresaApp
    {
        private readonly IEmpresaService _empresaService;
        private readonly IEnderecoService _enderecoService;
        private readonly IAspNetPerfilService _perfilService;

        public EmpresaApp(IEmpresaService empresaService,
            IEnderecoService enderecoService,
            IAspNetPerfilService perfilService
            )
        {
            _empresaService = empresaService;
            _enderecoService = enderecoService;
            _perfilService = perfilService;
        }

        public object[][] GetHashPorteEmpresa()
        {
            return _empresaService.GetHashPorteEmpresa();
        }

        public object[][] GetHashRamoEmpresa()
        {
            return _empresaService.GetHashRamoEmpresa();
        }

        public async Task<IDictionary<string, ModelState>> NovoCadastroAsync(ApplicationUserManager UserManager,
            EmpresaNovaVM model)
        {
            var resultado = new Dictionary<string, ModelState>();
            var empresaNova = model.ToModel();


            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto = _enderecoService.ValidaEndereco(empresaNova.TBEndereco);
                if (tudoCerto)
                    tudoCerto = await _empresaService.CriarNovaEmpresaAsync(empresaNova);
                if (tudoCerto) Commit();

                var user = new AspNetUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    EmpresaID = empresaNova.EmpresaID,
                    EmailConfirmed = true
                };

                if (model.TipoEmpresaGerador)
                    user.Perfis.Add(_perfilService.GetPerfilByNome("externoGerador"));
                if (model.TipoEmpresaColetor)
                    user.Perfis.Add(_perfilService.GetPerfilByNome("externoColetor"));
                if (model.TipoEmpresaDestinacao)
                    user.Perfis.Add(_perfilService.GetPerfilByNome("externoTratamento"));
                if (model.TipoEmpresaDestinadorFinal)
                    user.Perfis.Add(_perfilService.GetPerfilByNome("externoDisposicaoFinal"));

                var senha = Guid.NewGuid().ToString().Substring(0, 8);
                var result = await UserManager.CreateAsync(user, senha);
                if (result.Succeeded)
                {
                    string menssagem = string.Format(VariaveisDefault.MensagemNovaEmpresa, model.Email, senha);
                    await UserManager.SendEmailAsync(user.Id, "Conta criada no sistema Redivivus", menssagem);
                }
                else
                {
                    var errors = string.Join(", ", result.Errors);

                    if (!resultado.ContainsKey("")) resultado.Add("", new ModelState());

                    resultado[""].Errors.Add(errors);
                }
            }
            catch (ArgumentException ex)
            {
                if (!resultado.ContainsKey(ex.ParamName)) resultado.Add(ex.ParamName, new ModelState());
                var lines = Regex.Split(ex.Message, "\r\n");
                resultado[ex.ParamName].Errors.Add(lines[0]);
            }
            catch (Exception ex)
            {
                if (!resultado.ContainsKey("")) resultado.Add("", new ModelState());

                resultado[""].Errors.Add(ex);
            }
            return resultado;
        }

        public async Task<IDictionary<string, ModelState>> EditarCadastroAsync(TBEmpresa tBEmpresa,
            DadosCadastraisVM model)
        {
            var resultado = new Dictionary<string, ModelState>();


            //var empresa = model.ToModel();

            if (model.DadosCadastraisId == tBEmpresa.EmpresaID)
            {
                resultado[""].Errors.Add(MensagensErro.empresaIDIncompativel);
                return resultado;
            }

            tBEmpresa.Celular = model.Celular;
            tBEmpresa.CNAE = model.Cnae;
            //tBEmpresa.CNPJ = model.Cnpj;
            tBEmpresa.InscricaoEsdatudal = model.InscricaoEstadual;
            tBEmpresa.InscricaoMunicipal = model.InscricaoMunicipal;
            tBEmpresa.nmFantasia = model.NomeFantasia;
            tBEmpresa.nmRazaoSocial = model.Nome;
            tBEmpresa.Alvara = model.Alvara;
            tBEmpresa.dtEmissaoAlvara = NullableHelper.ParseNullable<DateTime>(model.dtEmissaoAlvara, DateTime.TryParse);
            tBEmpresa.bVencIndeterminadoAlvara = model.bVencIndeterminadoAlvara;
            tBEmpresa.dtVencAlvara = NullableHelper.ParseNullable<DateTime>(model.dtVencAlvara, DateTime.TryParse);
            tBEmpresa.PorteEmpresaID = Int32.Parse(model.PorteEmpresaValor);
            tBEmpresa.RamoEmpresaID = Int32.Parse(model.RamoEmpresaValor);
            tBEmpresa.Site = model.Site;
            tBEmpresa.Telefone = model.Telefone;
            tBEmpresa.AlvaraFuncionamento = model.Alvara;
            tBEmpresa.TBEndereco = EnderecoVM.ToModel(model.Endereco);

            BeginTransaction();

            var tudoCerto = false;
            try
            {
                tudoCerto = _enderecoService.ValidaEndereco(tBEmpresa.TBEndereco);
                if (tudoCerto)
                {
                    foreach (var item in model.LicencaOperacional)
                    {
                        if (item.Status == (int) TipoPermissao.Excluir)
                        {
                            var find =
                                tBEmpresa.TBLicencaOperacaos.FirstOrDefault(
                                    x => x.LicencaOperacaoID == item.LicencaOperacionalId);
                            tBEmpresa.TBLicencaOperacaos.Remove(find);
                        }
                        else if(item.Status == (int) TipoPermissao.Alterar)
                        {
                            var find =
                                tBEmpresa.TBLicencaOperacaos.FirstOrDefault(
                                    x => x.LicencaOperacaoID == item.LicencaOperacionalId);
                            find.CodigoLicencaOperacao = item.NumeroLicencaOperacional;
                            find.nmLicencaOperacao = item.AtividadeLicenciada;
                            find.dtValidade = DateTime.Parse(item.VencimentoLicenca);
                        }else if (item.Status == (int) TipoPermissao.Incluir)
                        {
                            var find = new TBLicencaOperacao();
                            find.CodigoLicencaOperacao = item.NumeroLicencaOperacional;
                            find.nmLicencaOperacao = item.AtividadeLicenciada;
                            find.dtValidade = DateTime.Parse(item.VencimentoLicenca);
                            find.EmpresaID = tBEmpresa.EmpresaID;
                            tBEmpresa.TBLicencaOperacaos.Add(find);
                        }
                    }
                    tudoCerto = _empresaService.EditarCadastro(tBEmpresa);
                }
                    
                if (tudoCerto) await CommitAsync();


                
            }
            catch (ArgumentException ex)
            {
                if (!resultado.ContainsKey(ex.ParamName)) resultado.Add(ex.ParamName, new ModelState());
                var lines = Regex.Split(ex.Message, "\r\n");
                resultado[ex.ParamName].Errors.Add(lines[0]);
            }
            catch (Exception ex)
            {
                if (!resultado.ContainsKey("")) resultado.Add("", new ModelState());

                resultado[""].Errors.Add(ex);
            }
            return resultado;
        }

        public async Task<IDictionary<string, ModelState>> AddLicencaOperacional(TBEmpresa tBEmpresa,
            LicencaOperacionalVM licenciaOperacional)
        {
            var resultado = new Dictionary<string, ModelState>();


            BeginTransaction();

            var tudoCerto = false;
            try
            {
                var lo = licenciaOperacional.ToModel();
                if (_empresaService.AddLicencaOperacional(tBEmpresa.EmpresaID, lo)) Commit();
            }
            catch (ArgumentException ex)
            {
                if (!resultado.ContainsKey(ex.ParamName)) resultado.Add(ex.ParamName, new ModelState());
                var lines = Regex.Split(ex.Message, "\r\n");
                resultado[ex.ParamName].Errors.Add(lines[0]);
            }
            catch (Exception ex)
            {
                if (!resultado.ContainsKey("")) resultado.Add("", new ModelState());
                resultado[""].Errors.Add(ex);
            }

            return resultado;
        }

        public async Task<IDictionary<string, ModelState>> SalvarLicencaOperacional(TBEmpresa tBEmpresa,
            LicencaOperacionalVM licenciaOperacional)
        {
            var resultado = new Dictionary<string, ModelState>();
            var lo = licenciaOperacional.ToModel();

            BeginTransaction();

            var tudoCerto = false;
            try
            {
                if (_empresaService.UpdateLicencaOperacional(tBEmpresa.EmpresaID, lo)) Commit();
            }
            catch (ArgumentException ex)
            {
                if (!resultado.ContainsKey(ex.ParamName)) resultado.Add(ex.ParamName, new ModelState());
                var lines = Regex.Split(ex.Message, "\r\n");
                resultado[ex.ParamName].Errors.Add(lines[0]);
            }
            catch (Exception ex)
            {
                if (!resultado.ContainsKey("")) resultado.Add("", new ModelState());
                resultado[""].Errors.Add(ex);
            }

            return resultado;
        }

        public object[][] GetHashLicencaCadastrada(int? empresaId)
        {
            if (empresaId == null) return null;
            return _empresaService.GetHashLicencaCadastrada((int) empresaId);
        }

        public async Task<IDictionary<string, ModelState>> DeleteLicencaOperacional(TBEmpresa tBEmpresa,
            int licenciaOperacionalId)
        {
            var resultado = new Dictionary<string, ModelState>();


            BeginTransaction();

            var tudoCerto = false;
            try
            {
                if (_empresaService.DeleteLicencaOperacional(tBEmpresa.EmpresaID, licenciaOperacionalId)) Commit();
            }
            catch (ArgumentException ex)
            {
                if (!resultado.ContainsKey(ex.ParamName)) resultado.Add(ex.ParamName, new ModelState());
                var lines = Regex.Split(ex.Message, "\r\n");
                resultado[ex.ParamName].Errors.Add(lines[0]);
            }
            catch (Exception ex)
            {
                if (!resultado.ContainsKey("")) resultado.Add("", new ModelState());
                resultado[""].Errors.Add(ex);
            }

            return resultado;
        }

        public async Task<LicencaOperacionalVM> GetLicencaOperacional(TBEmpresa tBEmpresa, int licencaId)
        {
            var lo = await _empresaService.GetLicencaOperacional(tBEmpresa.EmpresaID, licencaId);
            return LicencaOperacionalVM.ToView(lo);
        }

        public async Task<EmpresaBuscaVM> GetEmpresaByCnpjAsync(string cnpj)
        {
            var emp = await _empresaService.GetByCnpjAsync(cnpj);
            if (emp == null)
            {
                throw new ArgumentException(MensagensErro.cnpjInexistente, "cnpj");
            }
            return EmpresaBuscaVM.ToView(emp);
        }
    }
}