using Simir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBContratoHistoricoMap : EntityTypeConfiguration<TBContratoHistorico>
    {
        public TBContratoHistoricoMap()
        {
            // Primary Key
            HasKey(t => t.ContratoHistoricoID);

            // Properties
            Property(t => t.NumeroContrato)
                .IsRequired()
                .HasMaxLength(255);

            Property(t => t.vlTotalContrato)
               .HasPrecision(10, 2);

            Property(t => t.vlPagoAteHoje)
               .HasPrecision(10, 2);



            // Relationships

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
