using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class TBPrestadoraServicosHistoricoMap : EntityTypeConfiguration<TBPrestadoraServicosHistorico>
    {
        public TBPrestadoraServicosHistoricoMap()
        {
            // Primary Key
            this.HasKey(t => t.PrestadoraServicosHistoricoID);

            // Properties
            this.Property(t => t.nmPrestadoraServico)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.nmResponsavel)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Telefone1)
                .HasMaxLength(25);

            this.Property(t => t.Telefone2)
                .HasMaxLength(25);

            this.Property(t => t.UserId)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TBPrestadoraServicosHistorico");
            this.Property(t => t.PrestadoraServicosHistoricoID).HasColumnName("PrestadoraServicosHistoricoID");
            this.Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            this.Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            this.Property(t => t.EnderecoID).HasColumnName("EnderecoID");
            this.Property(t => t.nmPrestadoraServico).HasColumnName("nmPrestadoraServico");
            this.Property(t => t.nmResponsavel).HasColumnName("nmResponsavel");
            this.Property(t => t.Telefone1).HasColumnName("Telefone1");
            this.Property(t => t.Telefone2).HasColumnName("Telefone2");
            this.Property(t => t.bPrefeitura).HasColumnName("bPrefeitura");
            this.Property(t => t.vlTotalContratado).HasColumnName("vlTotalContratado");
            this.Property(t => t.dtVencimento).HasColumnName("dtVencimento");
            this.Property(t => t.vlGari).HasColumnName("vlGari");
            this.Property(t => t.VlColetor).HasColumnName("VlColetor");
            this.Property(t => t.vlEncarregadoServico).HasColumnName("vlEncarregadoServico");
            this.Property(t => t.vlMotoristaCaminhaoAberto).HasColumnName("vlMotoristaCaminhaoAberto");
            this.Property(t => t.vlMotoristaaminhaoCompactador).HasColumnName("vlMotoristaaminhaoCompactador");
            this.Property(t => t.vlOperadorVarredeira).HasColumnName("vlOperadorVarredeira");
            this.Property(t => t.bRealizaPintura).HasColumnName("bRealizaPintura");
            this.Property(t => t.bRealizaVarricao).HasColumnName("bRealizaVarricao");
            this.Property(t => t.bRealizaPodasArvores).HasColumnName("bRealizaPodasArvores");
            this.Property(t => t.bRealizaLavagem).HasColumnName("bRealizaLavagem");
            this.Property(t => t.bRealizaColeta).HasColumnName("bRealizaColeta");
            this.Property(t => t.qtFuncPintura).HasColumnName("qtFuncPintura");
            this.Property(t => t.qtFundoReservaPintura).HasColumnName("qtFundoReservaPintura");
            this.Property(t => t.qtFuncPodasArvores).HasColumnName("qtFuncPodasArvores");
            this.Property(t => t.qtFundoReservaPodasArvores).HasColumnName("qtFundoReservaPodasArvores");
            this.Property(t => t.qtkmSargetaVarridoContratados).HasColumnName("qtkmSargetaVarridoContratados");
            this.Property(t => t.qtFuncVarricao).HasColumnName("qtFuncVarricao");
            this.Property(t => t.qtFundoReservaVarricao).HasColumnName("qtFundoReservaVarricao");
            this.Property(t => t.vlKmVarrido).HasColumnName("vlKmVarrido");
            this.Property(t => t.vlKgResidoVarrido).HasColumnName("vlKgResidoVarrido");
            this.Property(t => t.qtColetores).HasColumnName("qtColetores");
            this.Property(t => t.qtMotoristas).HasColumnName("qtMotoristas");
            this.Property(t => t.qtEncarregados).HasColumnName("qtEncarregados");
            this.Property(t => t.bAtivo).HasColumnName("bAtivo");
            this.Property(t => t.dtAlteracao).HasColumnName("dtAlteracao");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.qtTotalTrabalhadoresContratados).HasColumnName("qtTotalTrabalhadoresContratados");

            // Relationships
            this.HasRequired(t => t.TBPrefeitura)
                .WithMany(t => t.TBPrestadoraServicosHistoricoes)
                .HasForeignKey(d => d.PrefeituraID);
            this.HasRequired(t => t.TBPrestadoraServico)
                .WithMany(t => t.TBPrestadoraServicosHistoricoes)
                .HasForeignKey(d => d.PrestadoraServicosID);

        }
    }
}
