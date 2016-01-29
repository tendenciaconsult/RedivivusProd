using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBRotaMap : EntityTypeConfiguration<TBRota>
    {
        public TBRotaMap()
        {
            // Primary Key
            HasKey(t => t.RotasID);

            // Properties
            Property(t => t.nmRota)
                .HasMaxLength(255);

            Property(t => t.nmLocalDestino)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBRotas");
            Property(t => t.RotasID).HasColumnName("RotasID");
            Property(t => t.nmRota).HasColumnName("nmRota");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.DistanciaGaragemRota).HasColumnName("DistanciaGaragemRota");
            Property(t => t.DistanciaRotaDescarregamento).HasColumnName("DistanciaRotaDescarregamento");
            Property(t => t.ExtensaoRota).HasColumnName("ExtensaoRota");
            Property(t => t.qtPopulacaoAtendida).HasColumnName("qtPopulacaoAtendida");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.LocalDestinoID).HasColumnName("LocalDestinoID");
            Property(t => t.nmLocalDestino).HasColumnName("nmLocalDestino");

            // Relationships
            HasOptional(t => t.TBPrefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);
        }
    }
}