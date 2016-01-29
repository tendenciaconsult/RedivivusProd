using Simir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBServicoFuncionarioMap : EntityTypeConfiguration<TBServicoFuncionario>
    {
        public TBServicoFuncionarioMap()
        {
            // Primary Key
            HasKey(t => t.ServicoFuncionarioID);

            // Properties
            Property(t => t.qtFuncionarios).IsRequired();
            Property(t => t.vlEncargoPorFuncionario).HasPrecision(10,2);
            Property(t => t.vlPorFuncionario).HasPrecision(10, 2);


            

            HasRequired(t => t.ServicoFuncaoSubtitulo)
                .WithMany()
                .HasForeignKey(d => d.ServicoFuncaoSubtituloID);

        }
    }
}
