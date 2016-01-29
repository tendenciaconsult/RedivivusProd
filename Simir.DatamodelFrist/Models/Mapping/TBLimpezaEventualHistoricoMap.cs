using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBLimpezaEventualHistoricoMap : EntityTypeConfiguration<TBLimpezaEventualHistorico>
    {
        public TBLimpezaEventualHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.LimpezaEventualHistoricoID);

            // Properties
            this.Property(t => t.nmOutroLogradouro)
                .HasMaxLength(255);

            this.Property(t => t.nmProgramacao)
                .HasMaxLength(255);

            this.Property(t => t.userID)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.nmTipoProgramacao)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBLimpezaEventualHistorico");
            this.Property(t => t.LimpezaEventualHistoricoID).HasColumnName("LimpezaEventualHistoricoID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            this.Property(t => t.RegiaoAdministrativaID).HasColumnName("RegiaoAdministrativaID");
            this.Property(t => t.EnderecoBairroID).HasColumnName("EnderecoBairroID");
            this.Property(t => t.dtInicio).HasColumnName("dtInicio");
            this.Property(t => t.dtFim).HasColumnName("dtFim");
            this.Property(t => t.qtTintasUtilizados).HasColumnName("qtTintasUtilizados");
            this.Property(t => t.EnderecoLogradouroID).HasColumnName("EnderecoLogradouroID");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.nmOutroLogradouro).HasColumnName("nmOutroLogradouro");
            this.Property(t => t.nmProgramacao).HasColumnName("nmProgramacao");
            this.Property(t => t.qtGaris).HasColumnName("qtGaris");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.userID).HasColumnName("userID");
            this.Property(t => t.TipoProgramacao).HasColumnName("TipoProgramacao");
            this.Property(t => t.bServicoOrdinario).HasColumnName("bServicoOrdinario");
            this.Property(t => t.bFeiraLivre).HasColumnName("bFeiraLivre");
            this.Property(t => t.nmTipoProgramacao).HasColumnName("nmTipoProgramacao");
        }
    }
}
