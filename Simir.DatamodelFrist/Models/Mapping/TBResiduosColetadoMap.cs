using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBResiduosColetadoMap : EntityTypeConfiguration<TBResiduosColetado>
    {
        public TBResiduosColetadoMap()
        {
            // Primary Key
            this.HasKey(t => t.ResiduosColetadosID);

            // Properties
            this.Property(t => t.CnpjGeradora)
                .HasMaxLength(50);

            this.Property(t => t.nmRazaoSocialGeradora)
                .HasMaxLength(150);

            this.Property(t => t.nmPessoaLiberouColeta)
                .HasMaxLength(255);

            this.Property(t => t.CNPJDestinadora)
                .HasMaxLength(50);

            this.Property(t => t.RazaoSocialDestinadora)
                .HasMaxLength(150);

            this.Property(t => t.CNPJTransbordo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TBResiduosColetados");
            this.Property(t => t.ResiduosColetadosID).HasColumnName("ResiduosColetadosID");
            this.Property(t => t.EmpresaID).HasColumnName("EmpresaID");
            this.Property(t => t.RealizouTransbordo).HasColumnName("RealizouTransbordo");
            this.Property(t => t.CnpjGeradora).HasColumnName("CnpjGeradora");
            this.Property(t => t.nmRazaoSocialGeradora).HasColumnName("nmRazaoSocialGeradora");
            this.Property(t => t.nmPessoaLiberouColeta).HasColumnName("nmPessoaLiberouColeta");
            this.Property(t => t.CNPJDestinadora).HasColumnName("CNPJDestinadora");
            this.Property(t => t.RazaoSocialDestinadora).HasColumnName("RazaoSocialDestinadora");
            this.Property(t => t.DestinadoraFinal).HasColumnName("DestinadoraFinal");
            this.Property(t => t.dtMesReferencia).HasColumnName("dtMesReferencia");
            this.Property(t => t.CNPJTransbordo).HasColumnName("CNPJTransbordo");

            // Relationships
            this.HasRequired(t => t.TBEmpresa)
                .WithMany(t => t.TBResiduosColetados)
                .HasForeignKey(d => d.EmpresaID);

        }
    }
}
