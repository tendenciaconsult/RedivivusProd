using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBColetaExecutadaHistoricoMap : EntityTypeConfiguration<TBColetaExecutadaHistorico>
    {
        public TBColetaExecutadaHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.ColetaExecutadaHistoricoID);

            // Properties
            Property(t => t.nmProgramacao)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.Motivo)
                .HasMaxLength(800);

            Property(t => t.HoraSaidaGaragem)
                .HasMaxLength(5);

            Property(t => t.HoraChegadaGaragem)
                .HasMaxLength(5);

            Property(t => t.nmResiduoColetado)
                .HasMaxLength(100);

            Property(t => t.Observacao)
                .HasMaxLength(800);

            Property(t => t.UserId)
                .HasMaxLength(100);

            Property(t => t.TipoColetaConvencional)
                .IsRequired();

            Property(t => t.TipoColetaEspecifica)
               .IsRequired()
               .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBColetaExecutadaHistorico");
            Property(t => t.ColetaExecutadaHistoricoID).HasColumnName("ColetaExecutadaHistoricoID");
            Property(t => t.ColetaExecutadaID).HasColumnName("ColetaExecutadaID");
            Property(t => t.nmProgramacao).HasColumnName("nmProgramacao");
            Property(t => t.dtReferencia).HasColumnName("dtReferencia");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.ColetaEventualID).HasColumnName("ColetaEventualID");
            Property(t => t.bColetaRealizada).HasColumnName("bColetaRealizada");
            Property(t => t.Motivo).HasColumnName("Motivo");
            Property(t => t.HoraSaidaGaragem).HasColumnName("HoraSaidaGaragem");
            Property(t => t.HoraChegadaGaragem).HasColumnName("HoraChegadaGaragem");
            Property(t => t.qtGaris).HasColumnName("qtGaris");
            Property(t => t.ExtensaoPercorridaInicio).HasColumnName("ExtensaoPercorridaInicio");
            Property(t => t.DistanciaDescargaGaragem).HasColumnName("DistanciaDescargaGaragem");
            Property(t => t.nmResiduoColetado).HasColumnName("nmResiduoColetado");
            Property(t => t.Observacao).HasColumnName("Observacao");
            Property(t => t.bAtivo).HasColumnName("bAtivo");
            Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}