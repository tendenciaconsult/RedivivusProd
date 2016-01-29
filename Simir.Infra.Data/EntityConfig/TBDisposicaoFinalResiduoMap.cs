using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBDisposicaoFinalResiduoMap : EntityTypeConfiguration<TBDisposicaoFinalResiduo>
    {
        public TBDisposicaoFinalResiduoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DisposicaoFinalResiduoID, t.EmpresaID, 
                t.CNPJTransportadora, t.nmRazaoSocialTransportadora, 
                t.dtRecebimento, t.qtRejeito, t.bAterroControlado });

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



            // Table & Column Mappings
            this.ToTable("TBDisposicaoFinalResiduo");
            this.Property(t => t.DisposicaoFinalResiduoID).HasColumnName("DisposicaoFinalResiduoID");
            this.Property(t => t.EmpresaID).HasColumnName("EmpresaID");
            this.Property(t => t.CNPJTransportadora).HasColumnName("CNPJTransportadora");
            this.Property(t => t.nmRazaoSocialTransportadora).HasColumnName("nmRazaoSocialTransportadora");
            this.Property(t => t.dtRecebimento).HasColumnName("dtRecebimento");
            this.Property(t => t.qtRejeito).HasColumnName("qtRejeito");
            this.Property(t => t.bAterroControlado).HasColumnName("bAterroControlado");


            // Relationships
            this.HasRequired(t => t.TBEmpresa)
                .WithMany()
                .HasForeignKey(d => d.EmpresaID);

        }
    }
}
