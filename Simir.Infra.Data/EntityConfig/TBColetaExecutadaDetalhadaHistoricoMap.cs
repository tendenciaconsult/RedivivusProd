using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBColetaExecutadaDetalhadaHistoricoMap : EntityTypeConfiguration<TBColetaExecutadaDetalhadaHistorico>
    {
        public TBColetaExecutadaDetalhadaHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.ColetaExecutadaDetalhadaHistoricoID);

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

            Property(t => t.UserId)
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBColetaExecutadaDetalhadaHistorico");
            Property(t => t.ColetaExecutadaDetalhadaHistoricoID).HasColumnName("ColetaExecutadaDetalhadaHistoricoID");
            Property(t => t.ColetaExecutadaDetalhadaID).HasColumnName("ColetaExecutadaDetalhadaID");
            Property(t => t.HoraChegadaRota).HasColumnName("HoraChegadaRota");
            Property(t => t.LocalEnchimentoCaminhao).HasColumnName("LocalEnchimentoCaminhao");
            Property(t => t.ExtensaoPercorridaEnchimento).HasColumnName("ExtensaoPercorridaEnchimento");
            Property(t => t.HoraEnchimento).HasColumnName("HoraEnchimento");
            Property(t => t.horaChegadaLocalDescarga).HasColumnName("horaChegadaLocalDescarga");
            Property(t => t.QtResiduo).HasColumnName("QtResiduo");
            Property(t => t.PlacaVeiculo).HasColumnName("PlacaVeiculo");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}