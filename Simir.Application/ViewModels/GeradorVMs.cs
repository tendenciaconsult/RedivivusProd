using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Simir.Application.Helpers;
using Simir.Domain;
using Simir.Domain.Entities;
using Simir.Domain.Enuns;

namespace Simir.Application.ViewModels
{
    public class DadosCadastraisVM
    {
        public DadosCadastraisVM()
        {
            Endereco = new EnderecoVM();

            LicencaOperacional = new List<LicencaOperacionalVM>();
        }

        public int DadosCadastraisId { get; set; }

        [Required(ErrorMessage = @"Digite o nome da empresa")]
        [DisplayName(@"Razão Social")]
        public string Nome { get; set; }

        [Required(ErrorMessage = @"Digite o nome fantasia")]
        [DisplayName(@"Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [DisplayName(@"Telefone")]
        [InputMask("(99)9999-9999")]
        public string Telefone { get; set; }

        [DisplayName(@"Celular")]
        [InputMask("(99)99999-9999")]
        public string Celular { get; set; }

        [Display(Name = @"Inscrição Estadual")]
        [StringLength(20)]
        public string InscricaoEstadual { get; set; }

        [Display(Name = "Inscrição Municipal", Description = "Inscrição Municipal (CCM)")]
        [StringLength(20)]
        public string InscricaoMunicipal { get; set; }

        [Display(Name = "CNAE", Description = "Código CNAE")]
        [StringLength(20)]
        public string Cnae { get; set; }

        [Display(Name = "Alvará", Description = "Número de Alvará de Funcionamento")]
        [StringLength(20)]
        public string Alvara { get; set; }

        [Display(Name = @"Data de Emissão do Alvará")]
        [StringLength(10)]
        [InputMask("99/99/9999")]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = @"Data inválida")]
        public string dtEmissaoAlvara { get; set; }

        [Display(Name = "Indeterminado", Description = "Data de vencimento de Alvará de funcionamento")]
        public bool bVencIndeterminadoAlvara { get; set; }

        [Display(Name = @"Data de Vencimento do Alvará")]
        [StringLength(10)]
        [InputMask("99/99/9999")]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = @"Data inválida")]
        public string dtVencAlvara { get; set; }

        [Display(Name = "Tipo de Empresa")]
        [StringLength(20)]
        [Required(ErrorMessage = "Selecione o ramo principal da empresa")]
        public string RamoEmpresaValor { get; set; }

        public string RamoEmpresaDescricao { get; set; }

        [Display(Name = "Porte da Empresa")]
        [StringLength(40)]
        [Required(ErrorMessage = "Selecione o porte da empresa")]
        public string PorteEmpresaValor { get; set; }

        public string PorteEmpresaDescricao { get; set; }


        [RegularExpression(@"^(http[s]?://)?(www\.)?[a-zA-Z0-9-\.]+\.(com|org|net|mil|edu|ca|co.uk|com.au|gov|br)$",
            ErrorMessage = "Url inválida")]
        [Display(Name = "Site próprio", Description = "ex.: www.tendenciaconsult.com.br")]
        [StringLength(100)]
        public string Site { get; set; }

        public IList<LicencaOperacionalVM> LicencaOperacional { get; set; }

        public virtual EnderecoVM Endereco { get; set; }

        public static DadosCadastraisVM Fake()
        {
            return new DadosCadastraisVM
            {
                Nome = "Hitech LTDA",
                NomeFantasia = "Hitech Revolution",
                Telefone = "(27)32229887",
                Celular = "(27)999939889",
                InscricaoEstadual = "716237162",
                InscricaoMunicipal = "213123123",
                Cnae = "1289739",
                Endereco = new EnderecoVM
                {
                    Numero = "101",
                    Complemento = "loja 04 - ed. Central",
                    Cep = "29010740",
                    LocalidadeMunicipioDescricao = "Vitória",
                    LocalidadeUfDescricao = "ES",
                    LocalidadeBairroDescricao = "Centro",
                    Endereco = "Desembargador Francisco Silva"
                }
            };
        }

        public static DadosCadastraisVM ToView(TBEmpresa tBEmpresa)
        {
            return new DadosCadastraisVM
            {
                Nome = tBEmpresa.nmRazaoSocial,
                NomeFantasia = tBEmpresa.nmFantasia,
                Telefone = tBEmpresa.Telefone,
                Celular = tBEmpresa.Celular,
                InscricaoEstadual = tBEmpresa.InscricaoEsdatudal,
                InscricaoMunicipal = tBEmpresa.InscricaoMunicipal,
                Cnae = tBEmpresa.CNAE,
                Alvara = tBEmpresa.Alvara,
                dtEmissaoAlvara = tBEmpresa.dtEmissaoAlvara.HasValue? tBEmpresa.dtEmissaoAlvara.Value.ToString("dd/MM/yyyy"):"",
                bVencIndeterminadoAlvara = tBEmpresa.bVencIndeterminadoAlvara,
                dtVencAlvara = tBEmpresa.dtVencAlvara.HasValue ? tBEmpresa.dtVencAlvara.Value.ToString("dd/MM/yyyy") : "",
                //Cnpj = tBEmpresa.CNPJ,
                Site = tBEmpresa.Site,
                PorteEmpresaValor = tBEmpresa.PorteEmpresaID.ToString(),
                PorteEmpresaDescricao = tBEmpresa.TBPorteEmpresa.nmPorteEmpresa,
                RamoEmpresaValor = tBEmpresa.RamoEmpresaID.ToString(),
                RamoEmpresaDescricao = tBEmpresa.TBRamoEmpresa.nmRamoEmpresa,
                Endereco = EnderecoVM.ToView(tBEmpresa.TBEndereco),
                LicencaOperacional = LicencaOperacionalVM.ToView(tBEmpresa.TBLicencaOperacaos)
            };
        }
    }

    public class GeradorCompletoVM
    {
        public GeradorCompletoVM()
        {
            Endereco = new EnderecoVM();
        }

        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "Digite o nome da empresa")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o nome fantasia")]
        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [DisplayName("Telefone 1")]
        [InputMask("(99)9999-9999")]
        public string Telefone1 { get; set; }

        [DisplayName("Telefone 2")]
        [InputMask("(99)9999-9999")]
        public string Telefone2 { get; set; }

        [DisplayName("Celular")]
        [InputMask("(99)99999-9999")]
        public string Telefone3 { get; set; }

        [Display(Name = "Inscrição Estadual")]
        [StringLength(20)]
        public string InscricaoEstadual { get; set; }

        [Display(Name = "Inscrição Municipal", Description = "Inscrição Municipal (CCM)")]
        [StringLength(20)]
        public string InscricaoMunicipal { get; set; }

        [Display(Name = "CNAE", Description = "Código CNAE")]
        [StringLength(20)]
        public string Cnae { get; set; }

        [Display(Name = "Site próprio", Description = "ex.: www.tendenciaconsult.com.br")]
        [StringLength(100)]
        public string Site { get; set; }

        [Display(Name = "Nome do Responsável", Description = "Nome do Responsável pela Empresa")]
        public string NomeResponsavel { get; set; }

        public virtual EnderecoVM Endereco { get; set; }
        public virtual LicencaOperacionalVM LicencaOperacional { get; set; }
        public virtual ResiduoGeradoVM ResiduoGerado { get; set; }
        public virtual ColetaVM Coleta { get; set; }

        public static GeradorCompletoVM Fake()
        {
            return new GeradorCompletoVM
            {
                Nome = "Hitech LTDA",
                NomeFantasia = "Hitech Revolution",
                Telefone1 = "(27)32229887",
                Telefone2 = "(27)32229888",
                Telefone3 = "(27)999939889",
                InscricaoEstadual = "716237162",
                InscricaoMunicipal = "213123123",
                Cnae = "1289739",
                Site = "www.hitech.com.br",
                NomeResponsavel = "Otávio Mesquita",
                Endereco = new EnderecoVM
                {
                    Numero = "101",
                    Complemento = "loja 04 - ed. Central",
                    Cep = "29010740",
                    LocalidadeMunicipioDescricao = "Vitória",
                    LocalidadeUfDescricao = "ES",
                    LocalidadeBairroDescricao = "Centro",
                    Endereco = "Desembargador Francisco Silva"
                },
                LicencaOperacional = new LicencaOperacionalVM
                {
                    NumeroLicencaOperacional = "abc-12791273",
                    OrgaoLicenciador = "iema",
                    VencimentoLicenca = "27/10/2023"
                },
                ResiduoGerado = new ResiduoGeradoVM()
            };
        }
    }

    public class MtrVM
    {
        public int MtrID { get; set; }
        public string Url { get; set; }
        public string Arquivo { get; set; }
        public string DataMtr { get; set; }
        public int Tamanho { get; set; }

        internal static MtrVM ToView(TBGeradorMtr mtr)
        {
            return new MtrVM
            {
                MtrID = mtr.ArquivoID,
                Url = mtr.Url,
                Arquivo = mtr.nmArquivo,
                Tamanho = mtr.Tamanho,
                DataMtr = mtr.dtMtr.ToShortDateString()
            };
        }

        internal TBGeradorMtr ToModel()
        {
            return new TBGeradorMtr
            {
                ArquivoID = MtrID,
                Url = Url,
                nmArquivo = Arquivo,
                Tamanho = Tamanho,
                dtMtr = DateTime.Parse(DataMtr)
            };
        }

        internal static ICollection<MtrVM> ToView(IList<TBGeradorMtr> list)
        {
            var listRetorno = new List<MtrVM>();

            foreach (var item in list)
            {
                listRetorno.Add(ToView(item));
            }
            return listRetorno;
        }
    }


    public class ResiduosGeradosVM
    {
        public ResiduosGeradosVM()
        {
            TipoListaValor = "-1";
            TipoListaDescricao = "Classifique o tipo de lista...";

            RamoValor = "-1";
            RamoDescricao = "Classifique o ramo...";

            ClassificacaoResiduoValor = "-1";
            ClassificacaoResiduoDescricao = "Classifique o resíduo...";

            Residuos = new List<ResiduosEditVM>();
        }

        public int ResiduoGeradoID { get; set; }

        [Display(Name = "Mês Referência")]
        [StringLength(7)]
        [InputMask("99/9999")]
        public string MesReferencia { get; set; }



        [Display(Name = "Tipo de Lista")]
        [StringLength(20)]
        public string TipoListaValor { get; set; }

        public string TipoListaDescricao { get; set; }

        [Display(Name = "Atividade")]
        [StringLength(20)]
        public string RamoValor { get; set; }

        public string RamoDescricao { get; set; }

        [Display(Name = "Classificação dos RSS, RSU e RCC")]
        [StringLength(30)]
        public string ClassificacaoResiduoValor { get; set; }

        public string ClassificacaoResiduoDescricao { get; set; }
        
        
        public IList<ResiduosEditVM> Residuos { get; set; }
        
        public bool isPublico { get; set; }

        [Display(Name = "CNPJ")]
        [Ajuda("Digite o CNPJ  exato da empresa coletora e clique em buscar")]
        [RegularExpression(@"^\d{2}.\d{3}.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido")]
        [InputMask("99.999.999/9999-99")]
        public string ColetoraCnpj { get; set; }

        [Display(Name = "Razão Social")]
        public string ColetoraRazaoSocial { get; set; }

        [DisplayName("CNPJ")]
        [Ajuda("Digite o CNPJ exato da empresa de destino e clique em buscar")]
        [RegularExpression(@"^\d{2}.\d{3}.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido")]
        [InputMask("99.999.999/9999-99")]
        public string DestinoCnpj { get; set; }

        [Display(Name = "Razão Social")]
        public string DestinoRazaoSocial { get; set; }
        

        //public ICollection<GeradorMtrVM> Mtrs { get; set; }
        public static ResiduosGeradosVM Fake()
        {
            return new ResiduosGeradosVM
            {
            };
        }

        public TBResiduosGerados ToModel()
        {
            return new TBResiduosGerados
            {
                CnpjColetora = ColetoraCnpj,
                CNPJDestinadora = DestinoCnpj,
                nmRazaoSocialColetora = ColetoraRazaoSocial,
                ColetoraPublica = isPublico
            };
        }

        public IList<TBResiduosGerados> ToModel(int empresaID)
        {
            if (Residuos == null || !Residuos.Any()) return null;
            return Residuos.Where(y=>y.Quantidade > 0).Select(x=>new TBResiduosGerados()
            {
                /*
                qtResiduo = x.Quantidade,
                CNPJDestinadora = DestinoCnpj,
                CnpjColetora = ColetoraCnpj,
                RazaoSocialDestinadora = DestinoRazaoSocial,
                nmRazaoSocialColetora = ColetoraRazaoSocial,
                ColetoraPublica = isPublico,
                EmpresaID = empresaID,
                ResiduoClassificadoID = x.Id,*/
                dtMesReferencia = DateTime.Parse(MesReferencia)
            }).ToList();
        }

        internal static ResiduosGeradosVM ToView(TBResiduosGerados model)
        {
            return new ResiduosGeradosVM()
            {
                ColetoraCnpj = model.CnpjColetora,
                ColetoraRazaoSocial = model.nmRazaoSocialColetora,
                DestinoCnpj = model.CNPJDestinadora,
                DestinoRazaoSocial = model.RazaoSocialDestinadora,
                MesReferencia = model.dtMesReferencia.ToString("MM/yy"),
                isPublico = model.ColetoraPublica,
                ResiduoGeradoID = model.ResiduosGeradosID,
                Residuos = ResiduosEditVM.ToView(model.Itens)
            };
        }
    }

    public class ResiduosEditVM
    {
        public int Id { get; set; }

        public int IdItem { get; set; }
        
        public int Status { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Qtde.")]
        public double Quantidade { get; set; }

        [Display(Name = "Unidade de medida")]
        public bool Medida { get; set; }

        internal static ICollection<TBResiduosGeradoItem> ToModel(IList<ResiduosEditVM> list, int idGerado)
        {
            return list.Select(x => ToModel(x, idGerado)).ToList();
        }

        internal static TBResiduosGeradoItem ToModel(ResiduosEditVM vm, int idGerado)
        {
            return new TBResiduosGeradoItem()
            {
                ResiduoClassificadoID = vm.Id,
                ResiduosGeradoItemID = vm.IdItem,
                ResiduosGeradoID = idGerado,
                emLitros = vm.Medida,
                qtResiduo = vm.Quantidade
            };
        }


        internal static ICollection<TBResiduosColetadoItem> ToModelColetado(IList<ResiduosEditVM> list, int idGerado)
        {
            return list.Select(x => ToModelColetado(x, idGerado)).ToList();
        }

        internal static TBResiduosColetadoItem ToModelColetado(ResiduosEditVM vm, int idGerado)
        {
            return new TBResiduosColetadoItem()
            {
                ResiduoClassificadoID = vm.Id,
                ResiduosColetadoItemID = vm.IdItem,
                ResiduosColetadoID = idGerado,
                emLitros = vm.Medida,
                qtResiduo = vm.Quantidade
            };
        }

        internal static IList<ResiduosEditVM> ToView(ICollection<TBResiduosGeradoItem> collection)
        {
            return collection.Select(ToView).ToList();
        }

        internal static ResiduosEditVM ToView(TBResiduosGeradoItem item)
        {
            return new ResiduosEditVM()
            {
                Id = item.ResiduoClassificadoID,
                IdItem = item.ResiduosGeradoItemID,
                Medida = item.emLitros,
                Quantidade = item.qtResiduo,
                Nome = item.ResiduoClassificado.Residuo.nmResiduo,
                Descricao = item.ResiduoClassificado.Residuo.Descricao,
                Status = (int)TipoPermissao.Consultar
            };
        }

        internal static IList<ResiduosEditVM> ToView(ICollection<TBResiduosColetadoItem> collection)
        {
            return collection.Select(ToView).ToList();
        }

        private static ResiduosEditVM ToView(TBResiduosColetadoItem item)
        {
            return new ResiduosEditVM()
            {
                Id = item.ResiduoClassificadoID,
                IdItem = item.ResiduosColetadoItemID,
                Medida = item.emLitros,
                Quantidade = item.qtResiduo,
                Nome = item.ResiduoClassificado.Residuo.nmResiduo,
                Descricao = item.ResiduoClassificado.Residuo.Descricao,
                Status = (int)TipoPermissao.Consultar
            };
        }

        internal static IList<ResiduosEditVM> ToView(ICollection<TBResiduosDestinadoreItem> collection)
        {
            return collection.Select(ToView).ToList();
        }

        private static ResiduosEditVM ToView(TBResiduosDestinadoreItem item)
        {
            return new ResiduosEditVM()
            {
                Id = item.ResiduoClassificadoID,
                IdItem = item.ResiduosDestinadoreItemID,
                Medida = item.emLitros,
                Quantidade = item.qtResiduo,
                Nome = item.ResiduoClassificado.Residuo.nmResiduo,
                Descricao = item.ResiduoClassificado.Residuo.Descricao,
                Status = (int)TipoPermissao.Consultar
            };
        }

        internal static ICollection<TBResiduosDestinadoreItem> ToModelDestinador(IList<ResiduosEditVM> list, int idDestinador)
        {
            return list.Select(x => ToModelDestinador(x, idDestinador)).ToList();
        }

        private static TBResiduosDestinadoreItem ToModelDestinador(ResiduosEditVM vm, int idDestinador)
        {
            return new TBResiduosDestinadoreItem()
            {
                ResiduoClassificadoID = vm.Id,
                ResiduosDestinadoreItemID = vm.IdItem,
                ResiduosDestinadorID = idDestinador,
                emLitros = vm.Medida,
                qtResiduo = vm.Quantidade
            };
        }
    }


    public class TotalGeradoVM
    {
        [Display(Name = "Total gerado")]
        public int TotalGerado { get; set; }

        public ICollection<ResiduoGeradoBasicoVM> ResiduosGerados { get; set; }

        public static TotalGeradoVM Fake()
        {
            return new TotalGeradoVM
            {
                TotalGerado = 20304,
                ResiduosGerados = new List<ResiduoGeradoBasicoVM>
                {
                    new ResiduoGeradoBasicoVM
                    {
                        DataColetada = "01/01/2015"
                    },
                    new ResiduoGeradoBasicoVM
                    {
                        DataColetada = "02/01/2015"
                    }
                }
            };
        }
    }

    public class ResiduoGeradoBasicoVM
    {
        public int Id { get; set; }
        [Display(Name = "Data Coletada")]
        public string DataColetada { get; set; }


        [Display(Name = "Público?")]
        public bool TransportadoraPublica { get; set; }

        [Display(Name = "Empresa Coletora")]
        public string Coletora { get; set; }

        [Display(Name = "Empresa Destinadora")]
        public string Destinadora { get; set; }

        internal static IList<ResiduoGeradoBasicoVM> ToView(IList<TBResiduosGerados> list)
        {
            var listRetorno = new List<ResiduoGeradoBasicoVM>();

            return list.Select(ToView).ToList();
        }

        internal static ResiduoGeradoBasicoVM ToView(TBResiduosGerados model)
        {
            return new ResiduoGeradoBasicoVM()
            {
                Id = model.ResiduosGeradosID,
                TransportadoraPublica =  model.ColetoraPublica,
                Coletora = model.nmRazaoSocialColetora ?? "Pública",
                Destinadora = model.RazaoSocialDestinadora ?? "Pública",
                DataColetada = model.dtMesReferencia.ToString("MM/yy")
            };
        }
    }


    public class ColetaVM
    {
        [Display(Name = "Nome da coletora")]
        public string Nome { get; set; }

        [Display(Name = "Cnpj da coletora")]
        [InputMask("99.999.999/9999-99")]
        public string Cnpj { get; set; }

        [Display(Name = "Dia da coleta")]
        [StringLength(10)]
        [InputMask("99/99/9999")]
        public string Dia { get; set; }

        [InputMask("999999999", Final = "kg")]
        public int Quantidade { get; set; }
    }

    public class LicencaOperacionalVM
    {
        public int LicencaOperacionalId { get; set; }

        [Display(Name = @"Atividade Licenciada")]
        [Required]
        [StringLength(30)]
        public string AtividadeLicenciada { get; set; }

        [StringLength(12)]
        [Required]
        [Display(Name = @"Nº Licença")]
        public string NumeroLicencaOperacional { get; set; }

        [Display(Name = @"Orgão Licenciador")]
        [StringLength(40)]
        public string OrgaoLicenciador { get; set; }

        [Display(Name = @"Validade")]
        [Required]
        [InputMask("99/99/9999")]
        public string VencimentoLicenca { get; set; }

        public int Status { get; set; }

        internal static IList<LicencaOperacionalVM> ToView(ICollection<TBLicencaOperacao> licencas)
        {
            var list = licencas.Select(ToView).ToList();
            return list;
        }

        internal static LicencaOperacionalVM ToView(TBLicencaOperacao licenca)
        {
            return new LicencaOperacionalVM
            {
                LicencaOperacionalId = licenca.LicencaOperacaoID,
                AtividadeLicenciada = licenca.nmLicencaOperacao,
                NumeroLicencaOperacional = licenca.CodigoLicencaOperacao,
                OrgaoLicenciador = "",
                VencimentoLicenca = licenca.dtValidade.ToShortDateString(),
                Status = 1
            };
        }

        public TBLicencaOperacao ToModel()
        {

            DateTime data;

            if (!DateTime.TryParse(VencimentoLicenca, out data))
            {
                throw new ArgumentException(MensagensErro.dataInvalida, "VencimentoLicenca");
            }

            return new TBLicencaOperacao
            {
                LicencaOperacaoID = LicencaOperacionalId,
                CodigoLicencaOperacao = NumeroLicencaOperacional,
                nmLicencaOperacao = AtividadeLicenciada,
                dtValidade = data,
                //todo orgão
            };
        }
    }

    public class ResiduoGeradoVM
    {
        [Display(Name = "Início", Description = "Dia em que iniciou a contagem da geração do resíduo.")]
        [StringLength(10)]
        [InputMask("99/99/9999")]
        public string Inicio { get; set; }

        [Display(Name = "Fim", Description = "Dia em que terminou a contagem da geração do resíduo.")]
        [StringLength(10)]
        [InputMask("99/99/9999")]
        public string Fim { get; set; }

        [InputMask("999999999", Final = "kg")]
        public int Quantidade { get; set; }

        public int UnidadeMedidaValor { get; set; }

        [Display(Name = "Capítulo")]
        [StringLength(200)]
        public string CapituloResiduoValor { get; set; }

        public string CapituloResiduoDescricao { get; set; }

        [Display(Name = "Subcapítulo")]
        [StringLength(200)]
        public string SubCapituloResiduoValor { get; set; }

        public string SubCapituloResiduoDescricao { get; set; }

        [Display(Name = "Resíduo")]
        [StringLength(200)]
        public string ResiduoValor { get; set; }

        public string ResiduoDescricao { get; set; }
    }

    public class TipoEmpresaEnum
    {
        public static string ToEnum(TipoEmpresa tipo)
        {
            if (tipo == TipoEmpresa.PrefeituraBase)
                return "Perefeitura Base";
            if (tipo == TipoEmpresa.Administradora)
                return "Administradora";
            if (tipo == TipoEmpresa.Transportadora)
                return "Transportadora";
            if (tipo == TipoEmpresa.Coletora)
                return "Coletora";
            if (tipo == TipoEmpresa.Geradora)
                return "Geradora";
            return "Outro tipo";
        }
    }
}