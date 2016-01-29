using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBColetaEventualMap : EntityTypeConfiguration<TBColetaEventual>
    {
        public TBColetaEventualMap()
        {
            // Primary Key
            HasKey(t => t.ColetaEventualID);

            // Properties
            Property(t => t.nmColetaEventual)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TBColetaEventual");
            Property(t => t.ColetaEventualID).HasColumnName("ColetaEventualID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            Property(t => t.RotasID).HasColumnName("RotasID");
            Property(t => t.dtColeta).HasColumnName("dtColeta");
            Property(t => t.DistanciaInicial).HasColumnName("DistanciaInicial");
            Property(t => t.DistanciaFinal).HasColumnName("DistanciaFinal");
            Property(t => t.qtGari).HasColumnName("qtGari");
            Property(t => t.nmColetaEventual).HasColumnName("nmColetaEventual");
            Property(t => t.bColetaOrdinaria).HasColumnName("bColetaOrdinaria");
            Property(t => t.qtColetaDia).HasColumnName("qtColetaDia");
            Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            HasRequired(t => t.TBPrefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);
            HasOptional(t => t.TBPrestadoraServico)
                .WithMany()
                .HasForeignKey(d => d.PrestadoraServicosID);
            //HasOptional(t => t.TBRota)
            //    .WithMany()
            //    .HasForeignKey(d => d.RotasID);

            HasOptional(x => x.TBColetaExecutada)
                .WithRequired(x => x.TBColetaEventual);
        }
    }
}