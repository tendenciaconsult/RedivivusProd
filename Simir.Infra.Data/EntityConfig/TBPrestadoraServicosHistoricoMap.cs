using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBPrestadoraServicosHistoricoMap : EntityTypeConfiguration<TBPrestadoraServicosHistorico>
    {
        public TBPrestadoraServicosHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.PrestadoraServicosHistoricoID);

            // Properties
            Property(t => t.nmPrestadoraServico)
                .IsRequired()
                .HasMaxLength(255);
            Property(t => t.nmPrestadoraServico)
                .IsRequired()
                .HasMaxLength(255);

            Property(t => t.nmRazaoSocial)
                .HasMaxLength(255);

            Property(t => t.CNPJ)
               .IsRequired()
               .HasMaxLength(18);
            /*
            Property(t => t.nmResponsavel)
                .IsRequired()
                .HasMaxLength(255);

            Property(t => t.Telefone1)
                .HasMaxLength(25);

            Property(t => t.Telefone2)
                .HasMaxLength(25);
                */

            // Table & Column Mappings
            ToTable("TBPrestadoraServicosHistorico");
            Property(t => t.PrestadoraServicosHistoricoID).HasColumnName("PrestadoraServicosHistoricoID");
            Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            Property(t => t.PrefeituraID).HasColumnName("PrefeituraID");
            Property(t => t.EnderecoID).HasColumnName("EnderecoID");
            Property(t => t.nmPrestadoraServico).HasColumnName("nmPrestadoraServico");

            /*
            Property(t => t.nmResponsavel).HasColumnName("nmResponsavel");
            Property(t => t.Telefone1).HasColumnName("Telefone1");
            Property(t => t.Telefone2).HasColumnName("Telefone2");
            Property(t => t.bPrefeitura).HasColumnName("bPrefeitura");
            Property(t => t.vlTotalContratado).HasColumnName("vlTotalContratado");
            Property(t => t.dtVencimento).HasColumnName("dtVencimento");
            Property(t => t.vlGari).HasColumnName("vlGari");
            Property(t => t.VlColetor).HasColumnName("VlColetor");
            Property(t => t.vlEncarregadoServico).HasColumnName("vlEncarregadoServico");
            Property(t => t.vlMotoristaCaminhaoAberto).HasColumnName("vlMotoristaCaminhaoAberto");
            Property(t => t.vlMotoristaaminhaoCompactador).HasColumnName("vlMotoristaaminhaoCompactador");
            Property(t => t.vlOperadorVarredeira).HasColumnName("vlOperadorVarredeira");
            Property(t => t.bRealizaPintura).HasColumnName("bRealizaPintura");
            Property(t => t.bRealizaVarricao).HasColumnName("bRealizaVarricao");
            Property(t => t.bRealizaPodasArvores).HasColumnName("bRealizaPodasArvores");
            Property(t => t.bRealizaLavagem).HasColumnName("bRealizaLavagem");
            Property(t => t.bRealizaColeta).HasColumnName("bRealizaColeta");
            Property(t => t.qtFuncPintura).HasColumnName("qtFuncPintura");
            Property(t => t.qtFundoReservaPintura).HasColumnName("qtFundoReservaPintura");
            Property(t => t.qtFuncPodasArvores).HasColumnName("qtFuncPodasArvores");
            Property(t => t.qtFundoReservaPodasArvores).HasColumnName("qtFundoReservaPodasArvores");
            Property(t => t.qtkmSargetaVarridoContratados).HasColumnName("qtkmSargetaVarridoContratados");
            Property(t => t.qtFuncVarricao).HasColumnName("qtFuncVarricao");
            Property(t => t.qtFundoReservaVarricao).HasColumnName("qtFundoReservaVarricao");
            Property(t => t.vlKmVarrido).HasColumnName("vlKmVarrido");
            Property(t => t.vlKgResidoVarrido).HasColumnName("vlKgResidoVarrido");
            Property(t => t.qtColetores).HasColumnName("qtColetores");
            Property(t => t.qtMotoristas).HasColumnName("qtMotoristas");
            Property(t => t.qtEncarregados).HasColumnName("qtEncarregados");
            */
        }
    }
}