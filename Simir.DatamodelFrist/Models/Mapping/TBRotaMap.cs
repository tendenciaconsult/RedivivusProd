using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBRotaMap : EntityTypeConfiguration<TBRota>
    {
        public TBRotaMap()
        {
            // Primary Key
            this.HasKey(t => t.RotasID);

            // Properties
            this.Property(t => t.nmRota)
                .HasMaxLength(255);

            this.Property(t => t.nmLocalDestino)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBRotas");
            this.Property(t => t.RotasID).HasColumnName("RotasID");
            this.Property(t => t.nmRota).HasColumnName("nmRota");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.DistanciaGaragemRota).HasColumnName("DistanciaGaragemRota");
            this.Property(t => t.DistanciaRotaDescarregamento).HasColumnName("DistanciaRotaDescarregamento");
            this.Property(t => t.ExtensaoRota).HasColumnName("ExtensaoRota");
            this.Property(t => t.qtPopulacaoAtendida).HasColumnName("qtPopulacaoAtendida");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.LocalDestinoID).HasColumnName("LocalDestinoID");
            this.Property(t => t.nmLocalDestino).HasColumnName("nmLocalDestino");

            // Relationships
            this.HasOptional(t => t.TBPrefeitura)
                .WithMany(t => t.TBRotas)
                .HasForeignKey(d => d.PrefeituraID);

        }
    }
}
