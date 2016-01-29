using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Simir.DatamodelFrist.Models.Mapping
{
    public class AspNetClientMap : EntityTypeConfiguration<AspNetClient>
    {
        public AspNetClientMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ClientKey)
                .HasMaxLength(100);

            this.Property(t => t.SimirUser_Id)
                .HasMaxLength(100);

            this.Property(t => t.FuncaoSelecionada)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("AspNetClients");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ClientKey).HasColumnName("ClientKey");
            this.Property(t => t.SimirUser_Id).HasColumnName("SimirUser_Id");
            this.Property(t => t.FuncaoSelecionada).HasColumnName("FuncaoSelecionada");

            // Relationships
            this.HasOptional(t => t.AspNetUser)
                .WithMany(t => t.AspNetClients)
                .HasForeignKey(d => d.SimirUser_Id);

        }
    }
}
