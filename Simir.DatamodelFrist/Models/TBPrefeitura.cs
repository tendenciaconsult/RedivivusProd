using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBPrefeitura
    {
        public TBPrefeitura()
        {
            this.AspNetPerfils = new List<AspNetPerfil>();
            this.TBColetaEventuals = new List<TBColetaEventual>();
            this.TBColetaExecutadas = new List<TBColetaExecutada>();
            this.TBColetaOrdinarias = new List<TBColetaOrdinaria>();
            this.TBEmpresas = new List<TBEmpresa>();
            this.TBFaleConoscoes = new List<TBFaleConosco>();
            this.TBFeiraLivres = new List<TBFeiraLivre>();
            this.TBLimpezaEventuals = new List<TBLimpezaEventual>();
            this.TBLimpezaExecutadas = new List<TBLimpezaExecutada>();
            this.TBLimpezaOrdinarias = new List<TBLimpezaOrdinaria>();
            this.TBLogEventos = new List<TBLogEvento>();
            this.TBPrestadoraServicosHistoricoes = new List<TBPrestadoraServicosHistorico>();
            this.TBPrestadoraServicos = new List<TBPrestadoraServico>();
            this.TBRegiaoAdministrativas = new List<TBRegiaoAdministrativa>();
            this.TBRotas = new List<TBRota>();
            this.TBSecretarias = new List<TBSecretaria>();
            this.TBSecretariasResponsabilidades = new List<TBSecretariasResponsabilidade>();
            this.TBUsuarios = new List<TBUsuario>();
        }

        public int PrefeituraID { get; set; }
        public string nmPrefeitura { get; set; }
        public string nmPrefeito { get; set; }
        public string CNPJ { get; set; }
        public string Site { get; set; }
        public Nullable<int> qtHabitantesUrbanos { get; set; }
        public Nullable<int> qthabitantesRurais { get; set; }
        public Nullable<int> EnderecoID { get; set; }
        public virtual ICollection<AspNetPerfil> AspNetPerfils { get; set; }
        public virtual ICollection<TBColetaEventual> TBColetaEventuals { get; set; }
        public virtual ICollection<TBColetaExecutada> TBColetaExecutadas { get; set; }
        public virtual ICollection<TBColetaOrdinaria> TBColetaOrdinarias { get; set; }
        public virtual ICollection<TBEmpresa> TBEmpresas { get; set; }
        public virtual TBEndereco TBEndereco { get; set; }
        public virtual ICollection<TBFaleConosco> TBFaleConoscoes { get; set; }
        public virtual ICollection<TBFeiraLivre> TBFeiraLivres { get; set; }
        public virtual ICollection<TBLimpezaEventual> TBLimpezaEventuals { get; set; }
        public virtual ICollection<TBLimpezaExecutada> TBLimpezaExecutadas { get; set; }
        public virtual ICollection<TBLimpezaOrdinaria> TBLimpezaOrdinarias { get; set; }
        public virtual ICollection<TBLogEvento> TBLogEventos { get; set; }
        public virtual ICollection<TBPrestadoraServicosHistorico> TBPrestadoraServicosHistoricoes { get; set; }
        public virtual ICollection<TBPrestadoraServico> TBPrestadoraServicos { get; set; }
        public virtual ICollection<TBRegiaoAdministrativa> TBRegiaoAdministrativas { get; set; }
        public virtual ICollection<TBRota> TBRotas { get; set; }
        public virtual ICollection<TBSecretaria> TBSecretarias { get; set; }
        public virtual ICollection<TBSecretariasResponsabilidade> TBSecretariasResponsabilidades { get; set; }
        public virtual ICollection<TBUsuario> TBUsuarios { get; set; }
    }
}
