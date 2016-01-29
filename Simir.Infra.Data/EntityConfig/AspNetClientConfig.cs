using System.Data.Entity.ModelConfiguration;
using Simir.Domain.Entities;

namespace Simir.Infra.Data.EntityConfig
{
    public class AspNetClientConfig : EntityTypeConfiguration<AspNetClient>
    {
        public AspNetClientConfig()
        {
            ToTable("AspNetClients");
            HasKey(p => p.Id);


            Property(t => t.ClientKey)
                .HasMaxLength(100);

            Property(t => t.FuncaoSelecionada)
                .HasMaxLength(100);
        }
    }
}