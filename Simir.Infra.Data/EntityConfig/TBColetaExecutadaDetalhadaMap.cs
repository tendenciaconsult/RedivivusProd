using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBColetaExecutadaDetalhadaMap : EntityTypeConfiguration<TBColetaExecutadaDetalhada>
    {
        public TBColetaExecutadaDetalhadaMap()
        {
            // Primary Key
            HasKey(t => t.ColetaExecutadaDetalhadaID);

            // Properties
            Property(t => t.HoraChegadaRota)
                .HasMaxLength(5);

            Property(t => t.LocalEnchimentoCaminhao)
                .HasMaxLength(150);

            Property(t => t.HoraEnchimento)
                .HasMaxLength(5);

            Property(t => t.horaChegadaLocalDescarga)
                .HasMaxLength(5);

            Property(t => t.PlacaVeiculo)
                .HasMaxLength(20);

            // Table & Column Mappings
            ToTable("TBColetaExecutadaDetalhada");
            Property(t => t.ColetaExecutadaDetalhadaID).HasColumnName("ColetaExecutadaDetalhadaID");
            Property(t => t.ColetaExecutadaID).HasColumnName("ColetaExecutadaID");
            Property(t => t.HoraChegadaRota).HasColumnName("HoraChegadaRota");
            Property(t => t.LocalEnchimentoCaminhao).HasColumnName("LocalEnchimentoCaminhao");
            Property(t => t.ExtensaoPercorridaEnchimento).HasColumnName("ExtensaoPercorridaEnchimento");
            Property(t => t.HoraEnchimento).HasColumnName("HoraEnchimento");
            Property(t => t.horaChegadaLocalDescarga).HasColumnName("horaChegadaLocalDescarga");
            Property(t => t.QtResiduo).HasColumnName("QtResiduo");
            Property(t => t.PlacaVeiculo).HasColumnName("PlacaVeiculo");
            Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            HasRequired(t => t.TBColetaExecutada)
                .WithMany(t => t.TBColetaExecutadaDetalhadas)
                .HasForeignKey(d => d.ColetaExecutadaID);
        }
    }
}