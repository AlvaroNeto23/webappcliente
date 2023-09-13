using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppCliente.Models;

namespace WebAppCliente.Data.Map
{
    public class LogradouroMap : IEntityTypeConfiguration<LogradouroModel>
    {
        public void Configure(EntityTypeBuilder<LogradouroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Logradouro).IsRequired().HasMaxLength(600);
            //builder.Property(x => x.IsActive).IsRequired();

            builder.Property(x => x.ClienteId);
            builder.HasOne(x => x.Cliente);
        }
    }
}
