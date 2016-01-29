using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBLogEventoMap : EntityTypeConfiguration<TBLogEvento>
    {
        public TBLogEventoMap()
        {
            // Primary Key
            this.HasKey(t => t.LogEventosID);

            // Properties
            this.Property(t => t.UserId)
                .HasMaxLength(128);

            this.Property(t => t.nmUsuario)
                .HasMaxLength(255);

            this.Property(t => t.Acao)
                .HasMaxLength(8000);

            // Table & Column Mappings
            this.ToTable("TBLogEventos");
            this.Property(t => t.LogEventosID).HasColumnName("LogEventosID");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.nmUsuario).HasColumnName("nmUsuario");
            this.Property(t => t.dtDataAcao).HasColumnName("dtDataAcao");
            this.Property(t => t.Acao).HasColumnName("Acao");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");

            // Relationships
            this.HasOptional(t => t.TBPrefeitura)
                .WithMany(t => t.TBLogEventos)
                .HasForeignKey(d => d.PrefeituraID);

        }
    }
}
