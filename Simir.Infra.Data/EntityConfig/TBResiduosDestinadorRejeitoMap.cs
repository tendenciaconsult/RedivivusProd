using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResiduosDestinadorRejeitoMap : EntityTypeConfiguration<TBResiduosDestinadorRejeito>
    {
        public TBResiduosDestinadorRejeitoMap()
        {
            // Primary Key
            HasKey(t => t.ResiduosDestinadorRejeitoID);

            // Properties
            Property(t => t.CNPJDestinadoraFinal)
                .HasMaxLength(50);

            Property(t => t.nmRazaoSocialDestinadoraFinal)
                .HasMaxLength(150);


            Property(t => t.CNPJTransportadora)
                .HasMaxLength(50);

            Property(t => t.nmRazaoSocialDestinadoraFinal)
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TBResiduosDestinadorRejeito");

            // Relationships
            HasRequired(t => t.TBEmpresa)
                .WithMany() //.WithMany(t => t.TBDestinacaoRejeitoes)
                .HasForeignKey(d => d.EmpresaID);
        }
    }
}