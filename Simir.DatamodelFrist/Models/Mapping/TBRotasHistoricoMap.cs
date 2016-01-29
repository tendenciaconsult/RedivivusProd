using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBRotasHistoricoMap : EntityTypeConfiguration<TBRotasHistorico>
    {
        public TBRotasHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.RotasHistoricoID);

            // Properties
            this.Property(t => t.nmRota)
                .HasMaxLength(255);

            this.Property(t => t.UserID)
                .HasMaxLength(100);

            this.Property(t => t.nmLocalDestino)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBRotasHistorico");
            this.Property(t => t.RotasHistoricoID).HasColumnName("RotasHistoricoID");
            this.Property(t => t.RotasID).HasColumnName("RotasID");
            this.Property(t => t.nmRota).HasColumnName("nmRota");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.DistanciaGaragemRota).HasColumnName("DistanciaGaragemRota");
            this.Property(t => t.DistanciaRotaDescarregamento).HasColumnName("DistanciaRotaDescarregamento");
            this.Property(t => t.ExtensaoRota).HasColumnName("ExtensaoRota");
            this.Property(t => t.qtPopulacaoAtendida).HasColumnName("qtPopulacaoAtendida");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.LocalDestinoID).HasColumnName("LocalDestinoID");
            this.Property(t => t.nmLocalDestino).HasColumnName("nmLocalDestino");
        }
    }
}
