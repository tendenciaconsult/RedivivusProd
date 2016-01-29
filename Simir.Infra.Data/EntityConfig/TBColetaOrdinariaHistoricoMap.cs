using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBColetaOrdinariaHistoricoMap : EntityTypeConfiguration<TBColetaOrdinariaHistorico>
    {
        public TBColetaOrdinariaHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.ColetaOrdinariaHistoricoID);

            // Properties
            Property(t => t.nmColetaOrdinaria)
                .IsRequired()
                .HasMaxLength(255);

            Property(t => t.UserId)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBColetaOrdinariaHistorico");
            Property(t => t.ColetaOrdinariaHistoricoID).HasColumnName("ColetaOrdinariaHistoricoID");
            Property(t => t.ColetaOrdinariaID).HasColumnName("ColetaOrdinariaID");
            Property(t => t.RotasID).HasColumnName("RotasID");
            Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            Property(t => t.nmColetaOrdinaria).HasColumnName("nmColetaOrdinaria");
            Property(t => t.bSegunda).HasColumnName("bSegunda");
            Property(t => t.bTerca).HasColumnName("bTerca");
            Property(t => t.bQuarta).HasColumnName("bQuarta");
            Property(t => t.bQuinta).HasColumnName("bQuinta");
            Property(t => t.bSexta).HasColumnName("bSexta");
            Property(t => t.bSabado).HasColumnName("bSabado");
            Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            Property(t => t.UserId).HasColumnName("UserID");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
        }
    }
}