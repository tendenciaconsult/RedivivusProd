using System;
using System.Security.Permissions;
using Simir.Domain.Helpers;
using Simir.Domain.Enuns;

namespace Simir.Domain.Entities
{
    public class TBPrestadoraServicosHistorico : Historico<TBPrestadoraServico>
    {
        public int PrestadoraServicosHistoricoID { get; set; }
        public int PrestadoraServicosID { get; set; }
        public int PrefeituraID { get; set; }
        public int? EnderecoID { get; set; }
        public string nmPrestadoraServico { get; set; }

        public string nmRazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public TipoPrestadoraServico tipoPrestadoraServicos { get; set; }

        /*
        public string nmResponsavel { get; set; }
        
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public bool bPrefeitura { get; set; }
        public int? vlTotalContratado { get; set; }
        public DateTime? dtVencimento { get; set; }
        public decimal? vlGari { get; set; }
        public decimal? VlColetor { get; set; }
        public decimal? vlEncarregadoServico { get; set; }
        public decimal? vlMotoristaCaminhaoAberto { get; set; }
        public decimal? vlMotoristaaminhaoCompactador { get; set; }
        public decimal? vlOperadorVarredeira { get; set; }
        public bool bRealizaPintura { get; set; }
        public bool bRealizaVarricao { get; set; }
        public bool bRealizaPodasArvores { get; set; }
        public bool bRealizaLavagem { get; set; }
        public bool bRealizaColeta { get; set; }
        public int? qtFuncPintura { get; set; }
        public decimal? qtFundoReservaPintura { get; set; }
        public int? qtFuncPodasArvores { get; set; }
        public decimal? qtFundoReservaPodasArvores { get; set; }
        public int? qtkmSargetaVarridoContratados { get; set; }
        public int? qtFuncVarricao { get; set; }
        public decimal? qtFundoReservaVarricao { get; set; }
        public decimal? vlKmVarrido { get; set; }
        public decimal? vlKgResidoVarrido { get; set; }
        public int? qtColetores { get; set; }
        public int? qtMotoristas { get; set; }
        public int? qtEncarregados { get; set; }
        public int? qtTotalTrabalhadoresContratados { get; set; }
        //public virtual ICollection<TBColetaEventual> TBColetaEventuals { get; set; }
        //public virtual ICollection<TBColetaEventualHistorico> TBColetaEventualHistoricoes { get; set; }
        //public virtual ICollection<TBColetaOrdinaria> TBColetaOrdinarias { get; set; }

    */
        public bool bAtivo { get; set; }
        // public virtual ICollection<TBPrestadoraServicosEquipamentosHistorico> PrestadoraServicosEquipamentosHistorico { get; set; }

        public override void To(TBPrestadoraServico pricipal)
        {
            PrestadoraServicosID = pricipal.PrestadoraServicosID;
            PrefeituraID = pricipal.PrefeituraID;
            EnderecoID = pricipal.EnderecoID;
            nmPrestadoraServico = pricipal.nmPrestadoraServico;
            nmRazaoSocial = pricipal.nmRazaoSocial;
            CNPJ = pricipal.CNPJ;
            tipoPrestadoraServicos = pricipal.tipoPrestadoraServicos;
            /*
            nmResponsavel = pricipal.nmResponsavel;
            Telefone1 = pricipal.Telefone1;
            Telefone2 = pricipal.Telefone2;
            bPrefeitura = pricipal.bPrefeitura;
            vlTotalContratado = pricipal.vlTotalContratado;
            dtVencimento = pricipal.dtVencimento;
            vlGari = pricipal.vlGari;
            VlColetor = pricipal.VlColetor;
            vlEncarregadoServico = pricipal.vlEncarregadoServico;
            vlMotoristaCaminhaoAberto = pricipal.vlMotoristaCaminhaoAberto;
            vlMotoristaaminhaoCompactador = pricipal.vlMotoristaaminhaoCompactador;
            vlOperadorVarredeira = pricipal.vlOperadorVarredeira;
            bRealizaPintura = pricipal.bRealizaPintura;
            bRealizaVarricao = pricipal.bRealizaVarricao;
            bRealizaPodasArvores = pricipal.bRealizaLavagem;
            bRealizaColeta = pricipal.bRealizaColeta;
            bRealizaPodasArvores = pricipal.bRealizaPodasArvores;
            qtFuncPintura = pricipal.qtFuncPintura;
            qtFundoReservaPintura = pricipal.qtFundoReservaPintura;
            qtFuncPodasArvores = pricipal.qtFuncPodasArvores;
            qtkmSargetaVarridoContratados = pricipal.qtkmSargetaVarridoContratados;
            qtFundoReservaPodasArvores = pricipal.qtFundoReservaPodasArvores;
            qtFuncVarricao = pricipal.qtFuncVarricao;
            qtFundoReservaVarricao = pricipal.qtFundoReservaVarricao;
            vlKmVarrido = pricipal.vlKmVarrido;
            vlKgResidoVarrido = pricipal.vlKgResidoVarrido;
            qtColetores = pricipal.qtColetores;
            qtMotoristas = pricipal.qtMotoristas;
            qtEncarregados = pricipal.qtEncarregados;
            
            qtTotalTrabalhadoresContratados = pricipal.qtTotalTrabalhadoresContratados;

    */
            bAtivo = pricipal.bAtivo;
            //PrestadoraServicosEquipamentosHistorico = pricipal.Equipamentos.Select(x => TBPrestadoraServicosEquipamentosHistorico.NewAndTo(x)).ToList();
        }
    }
}