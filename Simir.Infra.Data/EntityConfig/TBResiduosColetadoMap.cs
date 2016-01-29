using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResiduosColetadoMap : EntityTypeConfiguration<TBResiduosColetado>
    {
        public TBResiduosColetadoMap()
        {
            // Primary Key
            HasKey(t => t.ResiduosColetadosID);

            // Properties
            Property(t => t.CnpjGeradora)
                .HasMaxLength(50);

            Property(t => t.nmRazaoSocialGeradora)
                .HasMaxLength(150);

            Property(t => t.nmPessoaLiberouColeta)
                .HasMaxLength(255);

            Property(t => t.CNPJDestinadora)
                .HasMaxLength(50);

            Property(t => t.RazaoSocialDestinadora)
                .HasMaxLength(150);

            this.Property(t => t.CNPJTransbordo)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("TBResiduosColetados");
            Property(t => t.ResiduosColetadosID).HasColumnName("ResiduosColetadosID");
            Property(t => t.EmpresaID).HasColumnName("EmpresaID");
            Property(t => t.RealizouTransbordo).HasColumnName("RealizouTransbordo");
            Property(t => t.CnpjGeradora).HasColumnName("CnpjGeradora");
            Property(t => t.nmRazaoSocialGeradora).HasColumnName("nmRazaoSocialGeradora");
            Property(t => t.nmPessoaLiberouColeta).HasColumnName("nmPessoaLiberouColeta");
            Property(t => t.CNPJDestinadora).HasColumnName("CNPJDestinadora");
            Property(t => t.RazaoSocialDestinadora).HasColumnName("RazaoSocialDestinadora");
            Property(t => t.DestinadoraFinal).HasColumnName("DestinadoraFinal");

            // Relationships
            HasRequired(t => t.Empresa)
                .WithMany() //.WithMany(t => t.TBResiduosColetados)
                .HasForeignKey(d => d.EmpresaID);
            HasMany(t => t.Itens)
                .WithRequired(x => x.ResiduosColetado) //.WithMany(t => t.TBResiduosGerados)
                .HasForeignKey(d => d.ResiduosColetadoID);
        }
    }
}