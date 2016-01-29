using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBDisposicaoFinalResiduoMap : EntityTypeConfiguration<TBDisposicaoFinalResiduo>
    {
        public TBDisposicaoFinalResiduoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DisposicaoFinalResiduoID, t.EmpresaID, t.CNPJTransportadora, t.nmRazaoSocialTransportadora, t.dtRecebimento, t.qtRejeito, t.bAterroControlado, t.dtMesReferencia });

            // Properties
            this.Property(t => t.DisposicaoFinalResiduoID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.EmpresaID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CNPJTransportadora)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.nmRazaoSocialTransportadora)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.CNPJTransbordo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TBDisposicaoFinalResiduo");
            this.Property(t => t.DisposicaoFinalResiduoID).HasColumnName("DisposicaoFinalResiduoID");
            this.Property(t => t.EmpresaID).HasColumnName("EmpresaID");
            this.Property(t => t.CNPJTransportadora).HasColumnName("CNPJTransportadora");
            this.Property(t => t.nmRazaoSocialTransportadora).HasColumnName("nmRazaoSocialTransportadora");
            this.Property(t => t.dtRecebimento).HasColumnName("dtRecebimento");
            this.Property(t => t.qtRejeito).HasColumnName("qtRejeito");
            this.Property(t => t.bAterroControlado).HasColumnName("bAterroControlado");
            this.Property(t => t.CNPJTransbordo).HasColumnName("CNPJTransbordo");
            this.Property(t => t.dtMesReferencia).HasColumnName("dtMesReferencia");

            // Relationships
            this.HasRequired(t => t.TBEmpresa)
                .WithMany(t => t.TBDisposicaoFinalResiduos)
                .HasForeignKey(d => d.EmpresaID);

        }
    }
}
