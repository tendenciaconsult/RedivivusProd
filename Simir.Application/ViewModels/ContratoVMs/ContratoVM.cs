using Simir.Application.Helpers;
using Simir.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Domain.Entities;

namespace Simir.Application.ViewModels.ContratoVMs
{
    public class ContratoVM
    {
        public ContratoVM()
        {
            PrestadoraValor = "-1";
            PrestadoraDescricao = "Selecione uma prestadora...";

            Servicos = new List<ContratoServicoVM>();

            Funcoes = new List<ContratoFuncaoVM>();

            Veiculos = new List<ContratoVeiculoVM>();
            Equipamentos = new List<ContratoEquipamentoVM>();
        }
        public int ID { get; set; }
        public string Btn { get; set; }

        [Display(Name = @"Número do contrato")]
        [StringLength(50)]
        [Required(ErrorMessage = @"Número do contrato é obrigatório")]
        public string NumeroContrato { get; set; }

        [Display(Name = @"Data de Inicio do Contrato")]
        [StringLength(10)]
        [InputMask("99/99/9999")]
        [Required(ErrorMessage = @"Data de Inicio do Contrato é obrigatório")]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = @"Data inválida")]
        public string InicioContrato { get; set; }

        

        [Display(Name = @"Data de termino do Contrato")]
        [StringLength(10)]
        [InputMask("99/99/9999")]
        [Required(ErrorMessage = @"Data de termino do Contrato é obrigatório")]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = @"Data inválida")]
        public string TerminoContrato { get; set; }


        [Required(ErrorMessage = "Selecione uma Prestadora de Serviço")]
        [Display(Name = "Prestadora de Serviço")]
        [StringLength(50)]
        public string PrestadoraValor { get; set; }
        public string PrestadoraDescricao { get; set; }


        [Display(Name = "Total de Funcionarios")]
        [StringLength(6)]
        [InputMask("00.000", Final = "funcionarios", IsReverso = true)]
        public string TotalFuncionarios { get; set; }

        [Display(Name = "Valor Total do Contrato")]
        [InputMask("00.000.000,00", Final = "R$", IsReverso = true)]
        public string ValorTotalContrato { get; set; }

        [Display(Name = "Valor pago até a data atual")]
        [InputMask("00.000.000,00", Final = "R$", IsReverso = true)]
        public string ValorPagoAteHoje { get; set; }
        public Periodo FormaPagamento { get; set; }

        [Display(Name = @"Data do Último Pagamento")]
        [StringLength(10)]
        [InputMask("99/99/9999")]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = @"Data inválida")]
        public string DataUltimoPagamento { get; set; }


        [Display(Name = "Serviços Contratados")]
        public IList<ContratoServicoVM> Servicos { get; set; }


        [Display(Name = "Descreva as funções")]
        public IList<ContratoFuncaoVM> Funcoes { get; set; }


        [Display(Name = "Veículos utilizados")]
        public IList<ContratoVeiculoVM> Veiculos { get; set; }

        [Display(Name = "Equipamentos contratados")]
        public IList<ContratoEquipamentoVM> Equipamentos { get; set; }


        public static ContratoVM ToView(TBContrato pres)
        {
            return new ContratoVM
            {
                ID = pres.ContratoID,
                NumeroContrato = pres.NumeroContrato,
                InicioContrato = pres.dtInicioContrato.ToString(),
                TerminoContrato = pres.dtTerminoContrato.ToString(),
                PrestadoraValor = pres.PrestadoraID.ToString(),
                PrestadoraDescricao = pres.Prestadora.nmPrestadoraServico,
                TotalFuncionarios = pres.TotalFuncionarios.ToString(),
                ValorTotalContrato = pres.vlTotalContrato == null?"": pres.vlTotalContrato.Value.ToString(),
                ValorPagoAteHoje = pres.vlPagoAteHoje == null ? "" : pres.vlPagoAteHoje.Value.ToString(),
                FormaPagamento = pres.FormaPagamento,
                DataUltimoPagamento = pres.dtUltimoPagamento.ToString()
            };
        }
    }
}
