using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBLimpezaOrdinariaHistoryMap : EntityTypeConfiguration<TBLimpezaOrdinariaHistory>
    {
        public TBLimpezaOrdinariaHistoryMap()
        {
            // Primary Key
            HasKey(t => t.LimpezaOrdinariaHistoryID);

            // Properties
            Property(t => t.UserId)
                .HasMaxLength(100);

            Property(t => t.nmOutroServico)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("TBLimpezaOrdinariaHistory");
            Property(t => t.LimpezaOrdinariaHistoryID).HasColumnName("LimpezaOrdinariaHistoryID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
            Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            Property(t => t.EnderecoLogradouroID).HasColumnName("EnderecoLogradouroID");
            Property(t => t.ExtensaoSargetas).HasColumnName("ExtensaoSargetas");
            Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            Property(t => t.UserId).HasColumnName("UserId");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.FeiraLivreID).HasColumnName("FeiraLivreID");
            Property(t => t.TipoServico).HasColumnName("TipoServico");
            Property(t => t.nmOutroServico).HasColumnName("nmOutroServico");
            Property(t => t.bSegunda).HasColumnName("bSegunda");
            Property(t => t.qtVarricaoSegunda).HasColumnName("qtVarricaoSegunda");
            Property(t => t.bSegundaFiscalizado).HasColumnName("bSegundaFiscalizado");
            Property(t => t.bTerca).HasColumnName("bTerca");
            Property(t => t.qtVarricaoTerca).HasColumnName("qtVarricaoTerca");
            Property(t => t.bTercaFiscalizado).HasColumnName("bTercaFiscalizado");
            Property(t => t.bQuarta).HasColumnName("bQuarta");
            Property(t => t.qtVarricaoQuarta).HasColumnName("qtVarricaoQuarta");
            Property(t => t.bQuartaFiscalizado).HasColumnName("bQuartaFiscalizado");
            Property(t => t.bQuinta).HasColumnName("bQuinta");
            Property(t => t.qtVarricaoQuinta).HasColumnName("qtVarricaoQuinta");
            Property(t => t.bQuintaFiscalizado).HasColumnName("bQuintaFiscalizado");
            Property(t => t.bSexta).HasColumnName("bSexta");
            Property(t => t.qtVarricaoSexta).HasColumnName("qtVarricaoSexta");
            Property(t => t.bSextaFiscalizado).HasColumnName("bSextaFiscalizado");
            Property(t => t.bSabado).HasColumnName("bSabado");
            Property(t => t.qtVarricaoSabado).HasColumnName("qtVarricaoSabado");
            Property(t => t.bSabadoFiscalizado).HasColumnName("bSabadoFiscalizado");
            Property(t => t.bDomingo).HasColumnName("bDomingo");
            Property(t => t.qtVarricaoDomingo).HasColumnName("qtVarricaoDomingo");
            Property(t => t.bDomingoFiscalizado).HasColumnName("bDomingoFiscalizado");
            Property(t => t.qtGarisSegunda).HasColumnName("qtGarisSegunda");
            Property(t => t.qtGarisTerca).HasColumnName("qtGarisTerca");
            Property(t => t.qtGarisQuarta).HasColumnName("qtGarisQuarta");
            Property(t => t.qtGarisQuinta).HasColumnName("qtGarisQuinta");
            Property(t => t.qtGarisSexta).HasColumnName("qtGarisSexta");
            Property(t => t.qtGarisSabado).HasColumnName("qtGarisSabado");
            Property(t => t.qtGarisDomingo).HasColumnName("qtGarisDomingo");
        }
    }
}