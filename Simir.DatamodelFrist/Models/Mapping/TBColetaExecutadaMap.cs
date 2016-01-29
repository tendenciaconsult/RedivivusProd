using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBColetaExecutadaMap : EntityTypeConfiguration<TBColetaExecutada>
    {
        public TBColetaExecutadaMap()
        {
            // Primary Key
            this.HasKey(t => t.ColetaExecutadaID);

            // Properties
            this.Property(t => t.ColetaExecutadaID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.nmProgramacao)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Motivo)
                .HasMaxLength(800);

            this.Property(t => t.HoraSaidaGaragem)
                .HasMaxLength(5);

            this.Property(t => t.HoraChegadaGaragem)
                .HasMaxLength(5);

            this.Property(t => t.nmResiduoColetado)
                .HasMaxLength(100);

            this.Property(t => t.Observacao)
                .HasMaxLength(800);

            // Table & Column Mappings
            this.ToTable("TBColetaExecutada");
            this.Property(t => t.ColetaExecutadaID).HasColumnName("ColetaExecutadaID");
            this.Property(t => t.nmProgramacao).HasColumnName("nmProgramacao");
            this.Property(t => t.dtReferencia).HasColumnName("dtReferencia");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.bColetaRealizada).HasColumnName("bColetaRealizada");
            this.Property(t => t.Motivo).HasColumnName("Motivo");
            this.Property(t => t.HoraSaidaGaragem).HasColumnName("HoraSaidaGaragem");
            this.Property(t => t.HoraChegadaGaragem).HasColumnName("HoraChegadaGaragem");
            this.Property(t => t.qtGaris).HasColumnName("qtGaris");
            this.Property(t => t.ExtensaoPercorridaInicio).HasColumnName("ExtensaoPercorridaInicio");
            this.Property(t => t.DistanciaDescargaGaragem).HasColumnName("DistanciaDescargaGaragem");
            this.Property(t => t.ResiduoColetadoID).HasColumnName("ResiduoColetadoID");
            this.Property(t => t.nmResiduoColetado).HasColumnName("nmResiduoColetado");
            this.Property(t => t.Observacao).HasColumnName("Observacao");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");

            // Relationships
            this.HasRequired(t => t.TBPrefeitura)
                .WithMany(t => t.TBColetaExecutadas)
                .HasForeignKey(d => d.PrefeituraID);

        }
    }
}
