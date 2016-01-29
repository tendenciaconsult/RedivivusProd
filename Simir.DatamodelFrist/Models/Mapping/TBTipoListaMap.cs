using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBTipoListaMap : EntityTypeConfiguration<TBTipoLista>
    {
        public TBTipoListaMap()
        {
            // Primary Key
            this.HasKey(t => t.TipoListaID);

            // Properties
            this.Property(t => t.nmTipoLista)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBTipoLista");
            this.Property(t => t.TipoListaID).HasColumnName("TipoListaID");
            this.Property(t => t.nmTipoLista).HasColumnName("nmTipoLista");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
        }
    }
}
