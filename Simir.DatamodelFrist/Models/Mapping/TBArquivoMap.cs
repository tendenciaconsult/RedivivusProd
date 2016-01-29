using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBArquivoMap : EntityTypeConfiguration<TBArquivo>
    {
        public TBArquivoMap()
        {
            // Primary Key
            this.HasKey(t => t.ArquivoID);

            // Properties
            this.Property(t => t.nmArquivo)
                .HasMaxLength(100);

            this.Property(t => t.Url)
                .HasMaxLength(500);

            this.Property(t => t.Discriminator)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("TBArquivo");
            this.Property(t => t.ArquivoID).HasColumnName("ArquivoID");
            this.Property(t => t.EmpresaID).HasColumnName("EmpresaID");
            this.Property(t => t.nmArquivo).HasColumnName("nmArquivo");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.Discriminator).HasColumnName("Discriminator");
            this.Property(t => t.Tamanho).HasColumnName("Tamanho");
            this.Property(t => t.dtMtr).HasColumnName("dtMtr");

            // Relationships
            this.HasOptional(t => t.TBEmpresa)
                .WithMany(t => t.TBArquivoes)
                .HasForeignKey(d => d.EmpresaID);

        }
    }
}
