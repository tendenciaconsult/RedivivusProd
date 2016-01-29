using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBClassificacaoResiduoMap : EntityTypeConfiguration<TBClassificacaoResiduo>
    {
        public TBClassificacaoResiduoMap()
        {
            // Primary Key
            this.HasKey(t => t.ClassificacaoResiduoID);

            // Properties
            this.Property(t => t.nmClassificacao)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBClassificacaoResiduo");
            this.Property(t => t.ClassificacaoResiduoID).HasColumnName("ClassificacaoResiduoID");
            this.Property(t => t.nmClassificacao).HasColumnName("nmClassificacao");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.RamoID).HasColumnName("RamoID");

            // Relationships
            this.HasRequired(t => t.TBRamo)
                .WithMany(t => t.TBClassificacaoResiduos)
                .HasForeignKey(d => d.RamoID);

        }
    }
}
