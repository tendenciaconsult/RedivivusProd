using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class TBPrestadoraServicosEquipamentoMap : EntityTypeConfiguration<TBPrestadoraServicosEquipamento>
    {
        public TBPrestadoraServicosEquipamentoMap()
        {
            // Primary Key
            HasKey(t => t.PrestadoraServicosEquipamentosID);

            // Properties
            Property(t => t.nmEquipamento)
                .IsRequired()
                .HasMaxLength(100);


            // Table & Column Mappings
            ToTable("TBPrestadoraServicosEquipamentos");
            Property(t => t.PrestadoraServicosEquipamentosID).HasColumnName("PrestadoraServicosEquipamentosID");
            //this.Property(t => t.PrestadoraServicosID).HasColumnName("PrestadoraServicosID");
            Property(t => t.nmEquipamento).HasColumnName("nmEquipamento");
            Property(t => t.qtEquipamento).HasColumnName("qtEquipamento");
        }
    }

    public class TBPrestadoraServicosEquipamentoPodaMap : EntityTypeConfiguration<TBPrestadoraServicosEquipamentoPoda>
    {
    }

    public class TBPrestadoraServicosVarredeiraMap : EntityTypeConfiguration<TBPrestadoraServicosVarredeira>
    {
    }

    public class TBPrestadoraServicosCaminhaoMap : EntityTypeConfiguration<TBPrestadoraServicosCaminhao>
    {
    }
}