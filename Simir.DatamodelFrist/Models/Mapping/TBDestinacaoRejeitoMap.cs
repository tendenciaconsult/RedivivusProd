using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBDestinacaoRejeitoMap : EntityTypeConfiguration<TBDestinacaoRejeito>
    {
        public TBDestinacaoRejeitoMap()
        {
            // Primary Key
            this.HasKey(t => t.DestinacaoRejeitoID);

            // Properties
            this.Property(t => t.CNPJDestinadoraFinal)
                .HasMaxLength(50);

            this.Property(t => t.nmRazaoSocialDestinadoraFinal)
                .HasMaxLength(150);

            this.Property(t => t.CNPJTransportadora)
                .HasMaxLength(50);

            this.Property(t => t.nmRazaoSocialTransportadora)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TBDestinacaoRejeito");
            this.Property(t => t.DestinacaoRejeitoID).HasColumnName("DestinacaoRejeitoID");
            this.Property(t => t.EmpresaID).HasColumnName("EmpresaID");
            this.Property(t => t.dtDataRegistro).HasColumnName("dtDataRegistro");
            this.Property(t => t.CNPJDestinadoraFinal).HasColumnName("CNPJDestinadoraFinal");
            this.Property(t => t.nmRazaoSocialDestinadoraFinal).HasColumnName("nmRazaoSocialDestinadoraFinal");
            this.Property(t => t.qtRejeitoVinculado).HasColumnName("qtRejeitoVinculado");
            this.Property(t => t.CNPJTransportadora).HasColumnName("CNPJTransportadora");
            this.Property(t => t.nmRazaoSocialTransportadora).HasColumnName("nmRazaoSocialTransportadora");

            // Relationships
            this.HasOptional(t => t.TBEmpresa)
                .WithMany(t => t.TBDestinacaoRejeitoes)
                .HasForeignKey(d => d.EmpresaID);

        }
    }
}
