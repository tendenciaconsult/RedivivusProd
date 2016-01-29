using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBResiduosDestinadorRejeitoMap : EntityTypeConfiguration<TBResiduosDestinadorRejeito>
    {
        public TBResiduosDestinadorRejeitoMap()
        {
            // Primary Key
            this.HasKey(t => t.ResiduosDestinadorRejeitoID);

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
            this.ToTable("TBResiduosDestinadorRejeito");
            this.Property(t => t.ResiduosDestinadorRejeitoID).HasColumnName("ResiduosDestinadorRejeitoID");
            this.Property(t => t.EmpresaID).HasColumnName("EmpresaID");
            this.Property(t => t.CNPJDestinadoraFinal).HasColumnName("CNPJDestinadoraFinal");
            this.Property(t => t.nmRazaoSocialDestinadoraFinal).HasColumnName("nmRazaoSocialDestinadoraFinal");
            this.Property(t => t.qtRejeitoVinculado).HasColumnName("qtRejeitoVinculado");
            this.Property(t => t.CNPJTransportadora).HasColumnName("CNPJTransportadora");
            this.Property(t => t.nmRazaoSocialTransportadora).HasColumnName("nmRazaoSocialTransportadora");
            this.Property(t => t.emLitros).HasColumnName("emLitros");

            // Relationships
            this.HasRequired(t => t.TBEmpresa)
                .WithMany(t => t.TBResiduosDestinadorRejeitoes)
                .HasForeignKey(d => d.EmpresaID);

        }
    }
}
