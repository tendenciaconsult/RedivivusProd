using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBColetaEventualMap : EntityTypeConfiguration<TBColetaEventual>
    {
        public TBColetaEventualMap()
        {
            // Primary Key
            this.HasKey(t => t.ColetaEventualID);

            // Properties
            this.Property(t => t.nmColetaEventual)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TBColetaEventual");
            this.Property(t => t.ColetaEventualID).HasColumnName("ColetaEventualID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            this.Property(t => t.RotasID).HasColumnName("RotasID");
            this.Property(t => t.dtColeta).HasColumnName("dtColeta");
            this.Property(t => t.DistanciaInicial).HasColumnName("DistanciaInicial");
            this.Property(t => t.DistanciaFinal).HasColumnName("DistanciaFinal");
            this.Property(t => t.qtGari).HasColumnName("qtGari");
            this.Property(t => t.nmColetaEventual).HasColumnName("nmColetaEventual");
            this.Property(t => t.bColetaOrdinaria).HasColumnName("bColetaOrdinaria");
            this.Property(t => t.qtColetaDia).HasColumnName("qtColetaDia");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            this.HasRequired(t => t.TBPrefeitura)
                .WithMany(t => t.TBColetaEventuals)
                .HasForeignKey(d => d.PrefeituraID);
            this.HasOptional(t => t.TBPrestadoraServico)
                .WithMany(t => t.TBColetaEventuals)
                .HasForeignKey(d => d.PrestadoraServicosID);
            this.HasOptional(t => t.TBRota)
                .WithMany(t => t.TBColetaEventuals)
                .HasForeignKey(d => d.RotasID);

        }
    }
}
