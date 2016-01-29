using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBColetaOrdinariaMap : EntityTypeConfiguration<TBColetaOrdinaria>
    {
        public TBColetaOrdinariaMap()
        {
            // Primary Key
            HasKey(t => t.ColetaOrdinariaID);

            // Properties
            Property(t => t.nmColetaOrdinaria)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TBColetaOrdinaria");
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
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");

            // Relationships
            HasRequired(t => t.TBPrefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);
            HasRequired(t => t.TBPrestadoraServico)
                .WithMany()
                .HasForeignKey(d => d.PrestadoraServicosID);
            HasRequired(t => t.TBRota)
                .WithMany(t => t.TBColetaOrdinarias)
                .HasForeignKey(d => d.RotasID);
        }
    }
}