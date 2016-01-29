using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBColetaOrdinariaHistoricoMap : EntityTypeConfiguration<TBColetaOrdinariaHistorico>
    {
        public TBColetaOrdinariaHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.ColetaOrdinariaHistoricoID);

            // Properties
            this.Property(t => t.nmColetaOrdinaria)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.UserID)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBColetaOrdinariaHistorico");
            this.Property(t => t.ColetaOrdinariaHistoricoID).HasColumnName("ColetaOrdinariaHistoricoID");
            this.Property(t => t.ColetaOrdinariaID).HasColumnName("ColetaOrdinariaID");
            this.Property(t => t.RotasID).HasColumnName("RotasID");
            this.Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            this.Property(t => t.nmColetaOrdinaria).HasColumnName("nmColetaOrdinaria");
            this.Property(t => t.bSegunda).HasColumnName("bSegunda");
            this.Property(t => t.bTerca).HasColumnName("bTerca");
            this.Property(t => t.bQuarta).HasColumnName("bQuarta");
            this.Property(t => t.bQuinta).HasColumnName("bQuinta");
            this.Property(t => t.bSexta).HasColumnName("bSexta");
            this.Property(t => t.bSabado).HasColumnName("bSabado");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.bSegundaFiscalizado).HasColumnName("bSegundaFiscalizado");
            this.Property(t => t.bTercaFiscalizado).HasColumnName("bTercaFiscalizado");
            this.Property(t => t.bQuartaFiscalizado).HasColumnName("bQuartaFiscalizado");
            this.Property(t => t.bQuintaFiscalizado).HasColumnName("bQuintaFiscalizado");
            this.Property(t => t.bSextaFiscalizado).HasColumnName("bSextaFiscalizado");
            this.Property(t => t.bSabadoFiscalizado).HasColumnName("bSabadoFiscalizado");
            this.Property(t => t.bDomingo).HasColumnName("bDomingo");
            this.Property(t => t.bDomingoFiscalizado).HasColumnName("bDomingoFiscalizado");
            this.Property(t => t.qtGarisSegunda).HasColumnName("qtGarisSegunda");
            this.Property(t => t.qtGarisTerca).HasColumnName("qtGarisTerca");
            this.Property(t => t.qtGarisQuarta).HasColumnName("qtGarisQuarta");
            this.Property(t => t.qtGarisQuinta).HasColumnName("qtGarisQuinta");
            this.Property(t => t.qtGarisSexta).HasColumnName("qtGarisSexta");
            this.Property(t => t.qtGarisSabado).HasColumnName("qtGarisSabado");
            this.Property(t => t.qtGarisDomingo).HasColumnName("qtGarisDomingo");
            this.Property(t => t.qtColetaSegunda).HasColumnName("qtColetaSegunda");
            this.Property(t => t.qtColetaTerca).HasColumnName("qtColetaTerca");
            this.Property(t => t.qtColetaQuarta).HasColumnName("qtColetaQuarta");
            this.Property(t => t.qtColetaQuinta).HasColumnName("qtColetaQuinta");
            this.Property(t => t.qtColetaSexta).HasColumnName("qtColetaSexta");
            this.Property(t => t.qtColetaSabado).HasColumnName("qtColetaSabado");
            this.Property(t => t.qtColetaDomingo).HasColumnName("qtColetaDomingo");
        }
    }
}
