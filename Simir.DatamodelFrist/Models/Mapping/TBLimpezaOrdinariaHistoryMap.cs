using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBLimpezaOrdinariaHistoryMap : EntityTypeConfiguration<TBLimpezaOrdinariaHistory>
    {
        public TBLimpezaOrdinariaHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.LimpezaOrdinariaHistoryID);

            // Properties
            this.Property(t => t.UserID)
                .HasMaxLength(100);

            this.Property(t => t.nmOutroServico)
                .HasMaxLength(50);

            this.Property(t => t.nmProgramacao)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBLimpezaOrdinariaHistory");
            this.Property(t => t.LimpezaOrdinariaHistoryID).HasColumnName("LimpezaOrdinariaHistoryID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
            this.Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            this.Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            this.Property(t => t.EnderecoLogradouroID).HasColumnName("EnderecoLogradouroID");
            this.Property(t => t.ExtensaoSargetas).HasColumnName("ExtensaoSargetas");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.FeiraLivreID).HasColumnName("FeiraLivreID");
            this.Property(t => t.TipoServico).HasColumnName("TipoServico");
            this.Property(t => t.nmOutroServico).HasColumnName("nmOutroServico");
            this.Property(t => t.bSegunda).HasColumnName("bSegunda");
            this.Property(t => t.qtVarricaoSegunda).HasColumnName("qtVarricaoSegunda");
            this.Property(t => t.bSegundaFiscalizado).HasColumnName("bSegundaFiscalizado");
            this.Property(t => t.bTerca).HasColumnName("bTerca");
            this.Property(t => t.qtVarricaoTerca).HasColumnName("qtVarricaoTerca");
            this.Property(t => t.bTercaFiscalizado).HasColumnName("bTercaFiscalizado");
            this.Property(t => t.bQuarta).HasColumnName("bQuarta");
            this.Property(t => t.qtVarricaoQuarta).HasColumnName("qtVarricaoQuarta");
            this.Property(t => t.bQuartaFiscalizado).HasColumnName("bQuartaFiscalizado");
            this.Property(t => t.bQuinta).HasColumnName("bQuinta");
            this.Property(t => t.qtVarricaoQuinta).HasColumnName("qtVarricaoQuinta");
            this.Property(t => t.bQuintaFiscalizado).HasColumnName("bQuintaFiscalizado");
            this.Property(t => t.bSexta).HasColumnName("bSexta");
            this.Property(t => t.qtVarricaoSexta).HasColumnName("qtVarricaoSexta");
            this.Property(t => t.bSextaFiscalizado).HasColumnName("bSextaFiscalizado");
            this.Property(t => t.bSabado).HasColumnName("bSabado");
            this.Property(t => t.qtVarricaoSabado).HasColumnName("qtVarricaoSabado");
            this.Property(t => t.bSabadoFiscalizado).HasColumnName("bSabadoFiscalizado");
            this.Property(t => t.bDomingo).HasColumnName("bDomingo");
            this.Property(t => t.qtVarricaoDomingo).HasColumnName("qtVarricaoDomingo");
            this.Property(t => t.bDomingoFiscalizado).HasColumnName("bDomingoFiscalizado");
            this.Property(t => t.qtGarisSegunda).HasColumnName("qtGarisSegunda");
            this.Property(t => t.qtGarisTerca).HasColumnName("qtGarisTerca");
            this.Property(t => t.qtGarisQuarta).HasColumnName("qtGarisQuarta");
            this.Property(t => t.qtGarisQuinta).HasColumnName("qtGarisQuinta");
            this.Property(t => t.qtGarisSexta).HasColumnName("qtGarisSexta");
            this.Property(t => t.qtGarisSabado).HasColumnName("qtGarisSabado");
            this.Property(t => t.qtGarisDomingo).HasColumnName("qtGarisDomingo");
            this.Property(t => t.nmProgramacao).HasColumnName("nmProgramacao");
        }
    }
}
