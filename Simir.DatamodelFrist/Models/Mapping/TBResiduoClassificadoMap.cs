using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBResiduoClassificadoMap : EntityTypeConfiguration<TBResiduoClassificado>
    {
        public TBResiduoClassificadoMap()
        {
            // Primary Key
            this.HasKey(t => t.ResiduoClassificadoID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TBResiduoClassificado");
            this.Property(t => t.ResiduoClassificadoID).HasColumnName("ResiduoClassificadoID");
            this.Property(t => t.ResiduoListaID).HasColumnName("ResiduoListaID");
            this.Property(t => t.ResiduoAtividadeID).HasColumnName("ResiduoAtividadeID");
            this.Property(t => t.ResiduoClasseID).HasColumnName("ResiduoClasseID");
            this.Property(t => t.ResiduoID).HasColumnName("ResiduoID");

            // Relationships
            this.HasRequired(t => t.TBResiduo)
                .WithMany(t => t.TBResiduoClassificadoes)
                .HasForeignKey(d => d.ResiduoID);
            this.HasRequired(t => t.TBResiduoAtividade)
                .WithMany(t => t.TBResiduoClassificadoes)
                .HasForeignKey(d => d.ResiduoAtividadeID);
            this.HasRequired(t => t.TBResiduoClasse)
                .WithMany(t => t.TBResiduoClassificadoes)
                .HasForeignKey(d => d.ResiduoClasseID);
            this.HasRequired(t => t.TBResiduoLista)
                .WithMany(t => t.TBResiduoClassificadoes)
                .HasForeignKey(d => d.ResiduoListaID);

        }
    }
}
