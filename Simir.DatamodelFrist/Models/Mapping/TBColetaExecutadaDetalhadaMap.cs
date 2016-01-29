using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBColetaExecutadaDetalhadaMap : EntityTypeConfiguration<TBColetaExecutadaDetalhada>
    {
        public TBColetaExecutadaDetalhadaMap()
        {
            // Primary Key
            this.HasKey(t => t.ColetaExecutadaDetalhadaID);

            // Properties
            this.Property(t => t.HoraChegadaRota)
                .HasMaxLength(5);

            this.Property(t => t.LocalEnchimentoCaminhao)
                .HasMaxLength(150);

            this.Property(t => t.HoraEnchimento)
                .HasMaxLength(5);

            this.Property(t => t.horaChegadaLocalDescarga)
                .HasMaxLength(5);

            this.Property(t => t.PlacaVeiculo)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("TBColetaExecutadaDetalhada");
            this.Property(t => t.ColetaExecutadaDetalhadaID).HasColumnName("ColetaExecutadaDetalhadaID");
            this.Property(t => t.ColetaExecutadaID).HasColumnName("ColetaExecutadaID");
            this.Property(t => t.HoraChegadaRota).HasColumnName("HoraChegadaRota");
            this.Property(t => t.LocalEnchimentoCaminhao).HasColumnName("LocalEnchimentoCaminhao");
            this.Property(t => t.ExtensaoPercorridaEnchimento).HasColumnName("ExtensaoPercorridaEnchimento");
            this.Property(t => t.HoraEnchimento).HasColumnName("HoraEnchimento");
            this.Property(t => t.horaChegadaLocalDescarga).HasColumnName("horaChegadaLocalDescarga");
            this.Property(t => t.QtResiduo).HasColumnName("QtResiduo");
            this.Property(t => t.PlacaVeiculo).HasColumnName("PlacaVeiculo");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            this.HasRequired(t => t.TBColetaExecutada)
                .WithMany(t => t.TBColetaExecutadaDetalhadas)
                .HasForeignKey(d => d.ColetaExecutadaID);

        }
    }
}
