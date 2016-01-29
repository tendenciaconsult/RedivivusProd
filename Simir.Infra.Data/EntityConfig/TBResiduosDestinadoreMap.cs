using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBResiduosDestinadoreMap : EntityTypeConfiguration<TBResiduosDestinadore>
    {
        public TBResiduosDestinadoreMap()
        {
            // Primary Key
            HasKey(t => t.ResiduosDestinadoresID);

            // Properties
            Property(t => t.CNPJTransportadora)
                .HasMaxLength(50);
            Property(t => t.nmRazaoSocialTransportadora)
                .HasMaxLength(100);


            Property(t => t.CNPJTransbordo)
                .HasMaxLength(50);
            Property(t => t.nmRazaoSocialTransbordo)
                .HasMaxLength(100);

            
            // Table & Column Mappings
            ToTable("TBResiduosDestinadores");
            Property(t => t.ResiduosDestinadoresID).HasColumnName("ResiduosDestinadoresID");

            // Relationships
            HasOptional(t => t.Empresa)
                .WithMany() //.WithMany(t => t.TBResiduosDestinadores)
                .HasForeignKey(d => d.EmpresaID);

            HasMany(t => t.Itens)
                .WithRequired(x => x.ResiduosDestinador) //.WithMany(t => t.TBResiduosGerados)
                .HasForeignKey(d => d.ResiduosDestinadorID);
        }
    }
}