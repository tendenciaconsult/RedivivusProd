using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBResiduoAtividadeMap : EntityTypeConfiguration<TBResiduoAtividade>
    {
        public TBResiduoAtividadeMap()
        {
            // Primary Key
            this.HasKey(t => t.ResiduoAtividadeID);

            // Properties
            this.Property(t => t.nmResiduoAtividade)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(800);

            // Table & Column Mappings
            this.ToTable("TBResiduoAtividade");
            this.Property(t => t.ResiduoAtividadeID).HasColumnName("ResiduoAtividadeID");
            this.Property(t => t.nmResiduoAtividade).HasColumnName("nmResiduoAtividade");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
        }
    }
}
