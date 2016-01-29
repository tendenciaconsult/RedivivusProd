using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBLogEventoMap : EntityTypeConfiguration<TBLogEvento>
    {
        public TBLogEventoMap()
        {
            // Primary Key
            HasKey(t => t.LogEventosID);

            // Properties
            Property(t => t.UserId)
                .HasMaxLength(128);

            Property(t => t.nmUsuario)
                .HasMaxLength(255);

            Property(t => t.Acao)
                .HasMaxLength(8000);

            // Table & Column Mappings
            ToTable("TBLogEventos");
            Property(t => t.LogEventosID).HasColumnName("LogEventosID");
            Property(t => t.UserId).HasColumnName("UserId");
            Property(t => t.nmUsuario).HasColumnName("nmUsuario");
            Property(t => t.dtDataAcao).HasColumnName("dtDataAcao");
            Property(t => t.Acao).HasColumnName("Acao");

            HasOptional(t => t.Prefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);
        }
    }
}