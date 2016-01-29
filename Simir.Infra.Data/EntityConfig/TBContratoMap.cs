using Simir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBContratoMap : EntityTypeConfiguration<TBContrato>
    {
        public TBContratoMap()
        {
            // Primary Key
            HasKey(t => t.ContratoID);

            // Properties
            Property(t => t.NumeroContrato)
                .IsRequired()
                .HasMaxLength(255);

            Property(t => t.vlTotalContrato)
               .HasPrecision(10, 2);

            Property(t => t.vlPagoAteHoje)
               .HasPrecision(10, 2);



            // Relationships
            HasRequired(t => t.Prefeitura)
                .WithMany()
                .HasForeignKey(d => d.PrefeituraID);

            HasRequired(t => t.Prestadora)
                .WithMany()
                .HasForeignKey(d => d.PrestadoraID);


            HasMany(x => x.Servicos).WithMany().Map(cs =>
            {
                cs.MapLeftKey("ContratoID");
                cs.MapRightKey("ServicoID");
                cs.ToTable("TBContratoServicos");
            });

            HasMany(s => s.Funcoes)
                .WithRequired()
                .HasForeignKey(s => s.ContratoID);

            HasMany(s => s.Equipamentos)
                .WithRequired()
                .HasForeignKey(s => s.ContratoID);

            HasMany(s => s.Veiculos)
                .WithRequired()
                .HasForeignKey(s => s.ContratoID);

            /*
            Ignore(x => x.EquipamentosPoda);
            Ignore(x => x.EquipamentosVerredeira);
            Ignore(x => x.Caminhoes);

            HasMany(s => s.Equipamentos)
                .WithRequired(s => s.PrestadoraServico)
                .HasForeignKey(s => s.PrestadoraServicosID);
                */
        }
    }
}
