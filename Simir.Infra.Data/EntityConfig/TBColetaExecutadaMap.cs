using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBColetaExecutadaMap : EntityTypeConfiguration<TBColetaExecutada>
    {
        public TBColetaExecutadaMap()
        {
            // Primary Key
            HasKey(t => t.ColetaExecutadaID);

            // Properties
            Property(t => t.ColetaExecutadaID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

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

            Property(t => t.TipoColetaConvencional)
               .IsRequired();

            Property(t => t.TipoColetaEspecifica)
               .IsRequired()
               .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("TBColetaExecutada");
            Property(t => t.ColetaExecutadaID).HasColumnName("ColetaExecutadaID");
            Property(t => t.nmProgramacao).HasColumnName("nmProgramacao");
            Property(t => t.dtReferencia).HasColumnName("dtReferencia");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
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

            // Relationships
            this.HasRequired(t => t.TBPrefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);

            this.HasOptional(t => t.Transbordo)
                .WithMany()
                .HasForeignKey(d => d.TransbordoID);

            this.HasOptional(t => t.Destinador)
                .WithMany()
                .HasForeignKey(d => d.DestinadorID);

            this.HasOptional(t => t.Aterro)
                .WithMany()
                .HasForeignKey(d => d.AterroID);

        }
    }
}