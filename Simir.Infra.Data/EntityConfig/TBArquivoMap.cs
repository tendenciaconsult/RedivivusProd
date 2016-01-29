using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBArquivoMap : EntityTypeConfiguration<TBArquivo>
    {
        public TBArquivoMap()
        {
            // Primary Key
            HasKey(t => t.ArquivoID);

            // Properties
            Property(t => t.nmArquivo)
                .HasMaxLength(100);

            Property(t => t.Url)
                .HasMaxLength(500);

            /*
                        this.Property(t => t.Discriminator)
                            .IsRequired()
                            .HasMaxLength(128);
            */


            // Table & Column Mappings
            ToTable("TBArquivo");
            Property(t => t.ArquivoID).HasColumnName("ArquivoID");
            Property(t => t.nmArquivo).HasColumnName("nmArquivo");
            Property(t => t.Url).HasColumnName("Url");
            //this.Property(t => t.Discriminator).HasColumnName("Discriminator");
            Property(t => t.Tamanho).HasColumnName("Tamanho");
        }
    }
}