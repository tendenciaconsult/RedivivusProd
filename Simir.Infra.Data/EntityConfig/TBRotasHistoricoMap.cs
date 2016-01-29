using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBRotasHistoricoMap : EntityTypeConfiguration<TBRotasHistorico>
    {
        public TBRotasHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.RotasHistoricoID);

            // Properties
            Property(t => t.nmRota)
                .HasMaxLength(255);

            this.Property(t => t.UserId)
                .HasMaxLength(100);

            Property(t => t.nmLocalDestino)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBRotasHistorico");
            Property(t => t.RotasHistoricoID).HasColumnName("RotasHistoricoID");
            Property(t => t.RotasID).HasColumnName("RotasID");
            Property(t => t.nmRota).HasColumnName("nmRota");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.DistanciaGaragemRota).HasColumnName("DistanciaGaragemRota");
            Property(t => t.DistanciaRotaDescarregamento).HasColumnName("DistanciaRotaDescarregamento");
            Property(t => t.ExtensaoRota).HasColumnName("ExtensaoRota");
            Property(t => t.qtPopulacaoAtendida).HasColumnName("qtPopulacaoAtendida");
            Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            Property(t => t.UserId).HasColumnName("UserID");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.LocalDestinoID).HasColumnName("LocalDestinoID");
            Property(t => t.nmLocalDestino).HasColumnName("nmLocalDestino");
        }
    }
}