using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Simir.Application.Helpers;
using Simir.Domain.Entities;
using Simir.Domain.Enuns;

namespace Simir.Application.ViewModels
{
    public class PrestadoraServicoBasicoVM
    {
        public PrestadoraServicoBasicoVM(TBPrestadoraServico x)
        {
            PrestadoraServicosID = x.PrestadoraServicosID;
            nmPrestadoraServico = x.nmPrestadoraServico;
            nmRazaoSocial = x.nmRazaoSocial;

            tipoPrestadoraServicos = x.tipoPrestadoraServicos;
        }

        public int PrestadoraServicosID { get; set; }

        [Display(Name = "Prestadora de Serviços")]
        public string nmPrestadoraServico { get; set; }

        [Display(Name = "Razão Social")]
        public string nmRazaoSocial { get; set; }
        [Display(Name = "Tipo")]
        public TipoPrestadoraServico tipoPrestadoraServicos { get; set; }
    }

    public class PrestadoraServicoVM
    {
        public PrestadoraServicoVM()
        {/*
            Prestadoras = new List<PrestadoraServicoBasicoVM>();
            Equipamentos = new List<EquipamentoVM>();
            Varredeiros = new List<EquipamentoVM>();
            Caminhoes = new List<CaminhaoVM>();
            */
            Endereco = new EnderecoVM();
        }

        public int PrestadoraServicosID { get; set; }
        public string Btn { get; set; }

        [Required(ErrorMessage = "Digite o nome da Prestadora de Serviços")]
        [Display(Name = "Nome da Prestadora de Serviços")]
        [StringLength(250)]
        public string nmPrestadoraServico { get; set; }



        
        [Display(Name = "Nome da Razão Social")]
        [StringLength(250)]
        public string nmRazaoSocial { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "Digite o CNPJ")]
        [RegularExpression(@"^\d{2}.\d{3}.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido")]
        [InputMask("99.999.999/9999-99")]
        [CustomValidationCNPJ()]
        public string CNPJ { get; set; }
        public TipoPrestadoraServico tipoPrestadoraServicos { get; set; }



        /*

            
        [Required(ErrorMessage = "Total de funcionarios contratados obrigatório")]
        [Display(Name = "Quantidade Total de Funcionários contratados")]
        [InputMask("000.000.000", IsReverso = true)]
        public string qtTotalTrabalhadoresContratados { get; set; }


        [Required(ErrorMessage = "Digite o nome do Responsável")]
        [Display(Name = "Nome do Responsável")]
        [StringLength(250)]
        public string nmResponsavel { get; set; }


        [Required(ErrorMessage = "Digite o Telefone")]
        [Display(Name = "Telefone 1")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{4}-?\d{4}$", ErrorMessage = "Telefone inválido")]
        [InputMask("(99)9999-9999")]
        public string Telefone1 { get; set; }

        [Display(Name = "Telefone 2")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{4}-?\d{4}$", ErrorMessage = "Telefone inválido")]
        [InputMask("(99)9999-9999")]
        public string Telefone2 { get; set; }

        [Display(Name = "Prestadora de Serviço Terceirizada")]
        public bool bPrefeitura { get; set; }

        [Display(Name = "Valor Total do Contrato")]
        [InputMask("000.000.000", IsReverso = true, Final = "R$")]
        public string vlTotalContratado { get; set; }

        [Display(Name = "Vencimento do Contrato")]
        [InputMask("99/99/9999")]
        public string dtVencimento { get; set; }

        [Display(Name = "Salário pago por gari")]
        [InputMask("000.000,00", IsReverso = true, Final = "R$/mês")]
        public string vlGari { get; set; }

        [Display(Name = "Salário pago por gari responsável pela coleta.")]
        [InputMask("000.000,00", IsReverso = true, Final = "R$/mês")]
        public string VlColetor { get; set; }

        [Display(Name = "Salário pago por Encarregado de Serviço")]
        [InputMask("000.000,00", IsReverso = true, Final = "R$/mês")]
        public string vlEncarregadoServico { get; set; }

        [Display(Name = "Salário pago por Motorista de Caminhão Aberto")]
        [InputMask("000.000,00", IsReverso = true, Final = "R$/mês")]
        public string vlMotoristaCaminhaoAberto { get; set; }

        [Display(Name = "Salário pago por Motorista de Caminhão Compactador")]
        [InputMask("000.000,00", IsReverso = true, Final = "R$/mês")]
        public string vlMotoristaaminhaoCompactador { get; set; }

        [Display(Name = "Salário pago por Operador de Varredeira")]
        [InputMask("000.000,00", IsReverso = true, Final = "R$/mês")]
        public string vlOperadorVarredeira { get; set; }

        public bool bRealizaPintura { get; set; }
        public bool bRealizaVarricao { get; set; }
        public bool bRealizaPodasArvores { get; set; }
        public bool bRealizaLavagem { get; set; }
        public bool bRealizaColeta { get; set; }

        [Display(Name = "Número de funcionarios contratados")]
        [InputMask("000.000", IsReverso = true, Final = "funcionários")]
        public string qtFuncPintura { get; set; }

        [Display(Name = "Porcentagem equivalente a reserva técnica")]
        [InputMask("000,00", IsReverso = true, Final = "%")]
        public string qtFundoReservaPintura { get; set; }

        [Display(Name = "Número de funcionarios contratados")]
        [InputMask("000.000", IsReverso = true, Final = "funcionários")]
        public string qtFuncPodasArvores { get; set; }

        [Display(Name = "Porcentagem equivalente a reserva técnica")]
        [InputMask("000,00", IsReverso = true, Final = "%")]
        public string qtFundoReservaPodasArvores { get; set; }

        [Display(Name = "Número de funcionarios contratados")]
        [InputMask("000.000", IsReverso = true, Final = "funcionários")]
        public string qtFuncVarricao { get; set; }

        [Display(Name = "Porcentagem equivalente a reserva técnica")]
        [InputMask("000,00", IsReverso = true, Final = "%")]
        public string qtFundoReservaVarricao { get; set; }

        [Display(Name = "Quantidade de Km de sargeta varridas contratados")]
        [InputMask("000.000.000", IsReverso = true, Final = "Km")]
        public string qtkmSargetaVarridoContratados { get; set; }

        [Display(Name = "Valor pago por Km de sargeta varrida")]
        [InputMask("000.000,99", IsReverso = true, Final = "R$/Km")]
        public string vlKmVarrido { get; set; }

        [Display(Name = "Valor pago por Kg de resíduo varrido")]
        [InputMask("000.000,99", IsReverso = true, Final = "R$/Kg")]
        public string vlKgResidoVarrido { get; set; }

        [Display(Name = "Número de Coletores Contratados")]
        [InputMask("000.000", IsReverso = true, Final = "funcionários")]
        public string qtColetores { get; set; }

        [Display(Name = "Número de Motoristas Contratados")]
        [InputMask("000.000", IsReverso = true, Final = "funcionários")]
        public string qtMotoristas { get; set; }

        [Display(Name = "Número de Encarregados Contratados")]
        [InputMask("000.000", IsReverso = true, Final = "funcionários")]
        public string qtEncarregados { get; set; }

        [Display(Name = "Tipo e quantidade de equipamentos contratado")]
        public IList<EquipamentoVM> Equipamentos { get; set; }

        [Display(Name = "Tipo e quantidade de Equipamentos contratado")]
        public IList<EquipamentoVM> Varredeiros { get; set; }

        [Display(Name = "Tipo e quantidade de caminhões contratado")]
        public IList<CaminhaoVM> Caminhoes { get; set; }

        public ICollection<PrestadoraServicoBasicoVM> Prestadoras { get; set; }

    */

        public virtual EnderecoVM Endereco { get; set; }

        public static PrestadoraServicoVM ToView(TBPrestadoraServico pres)
        {
            return new PrestadoraServicoVM
            {
                PrestadoraServicosID = pres.PrestadoraServicosID,
                nmPrestadoraServico = pres.nmPrestadoraServico,
                nmRazaoSocial = pres.nmRazaoSocial,
                tipoPrestadoraServicos = pres.tipoPrestadoraServicos,
                CNPJ = pres.CNPJ,

                /*
                Telefone1 = pres.Telefone1,
                Telefone2 = pres.Telefone2,
                bPrefeitura = pres.bPrefeitura,
                vlTotalContratado = pres.vlTotalContratado.ToString(),
                dtVencimento = pres.dtVencimento.ToString(),
                vlGari = pres.vlGari.ToString(),
                VlColetor = pres.VlColetor.ToString(),
                vlEncarregadoServico = pres.vlEncarregadoServico.ToString(),
                vlMotoristaCaminhaoAberto = pres.vlMotoristaCaminhaoAberto.ToString(),
                vlMotoristaaminhaoCompactador = pres.vlMotoristaaminhaoCompactador.ToString(),
                vlOperadorVarredeira = pres.vlOperadorVarredeira.ToString(),
                bRealizaPintura = pres.bRealizaPintura,
                bRealizaVarricao = pres.bRealizaVarricao,
                bRealizaPodasArvores = pres.bRealizaPodasArvores,
                bRealizaLavagem = pres.bRealizaLavagem,
                bRealizaColeta = pres.bRealizaColeta,
                qtFuncPintura = pres.qtFuncPintura.ToString(),
                qtFundoReservaPintura = pres.qtFundoReservaPintura.ToString(),
                qtFuncPodasArvores = pres.qtFuncPodasArvores.ToString(),
                qtFundoReservaPodasArvores = pres.qtFundoReservaPodasArvores.ToString(),
                qtkmSargetaVarridoContratados = pres.qtkmSargetaVarridoContratados.ToString(),
                qtFuncVarricao = pres.qtFuncVarricao.ToString(),
                qtFundoReservaVarricao = pres.qtFundoReservaVarricao.ToString(),
                vlKmVarrido = pres.vlKmVarrido.ToString(),
                vlKgResidoVarrido = pres.vlKgResidoVarrido.ToString(),
                qtColetores = pres.qtColetores.ToString(),
                qtMotoristas = pres.qtMotoristas.ToString(),
                qtEncarregados = pres.qtEncarregados.ToString(),
                qtTotalTrabalhadoresContratados = pres.qtTotalTrabalhadoresContratados.ToString(),
                Equipamentos = EquipamentoVM.ToView(pres.EquipamentosPoda),
                Varredeiros = EquipamentoVM.ToView(pres.EquipamentosVerredeira),
                Caminhoes = CaminhaoVM.ToView(pres.Caminhoes),
                */
                Endereco = EnderecoVM.ToView(pres.TBEndereco)

            };
        }
    }
}