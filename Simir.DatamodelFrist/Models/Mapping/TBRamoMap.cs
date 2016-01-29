using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBRamoMap : EntityTypeConfiguration<TBRamo>
    {
        public TBRamoMap()
        {
            // Primary Key
            this.HasKey(t => t.RamoID);

            // Properties
            this.Property(t => t.nmRamo)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBRamo");
            this.Property(t => t.RamoID).HasColumnName("RamoID");
            this.Property(t => t.nmRamo).HasColumnName("nmRamo");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.TipoListaID).HasColumnName("TipoListaID");

            // Relationships
            this.HasRequired(t => t.TBTipoLista)
                .WithMany(t => t.TBRamoes)
                .HasForeignKey(d => d.TipoListaID);

        }
    }
}
