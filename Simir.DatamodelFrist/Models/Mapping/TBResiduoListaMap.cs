using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBResiduoListaMap : EntityTypeConfiguration<TBResiduoLista>
    {
        public TBResiduoListaMap()
        {
            // Primary Key
            this.HasKey(t => t.ResiduoListaID);

            // Properties
            this.Property(t => t.nmResiduoLista)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(800);

            // Table & Column Mappings
            this.ToTable("TBResiduoLista");
            this.Property(t => t.ResiduoListaID).HasColumnName("ResiduoListaID");
            this.Property(t => t.nmResiduoLista).HasColumnName("nmResiduoLista");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
        }
    }
}
