using Microsoft.EntityFrameworkCore;
using WebAppCliente.Data.Map;
using WebAppCliente.Models;

namespace WebAppCliente.Data
{
    public class WebAppClienteDbContext: DbContext
    {
        public WebAppClienteDbContext(DbContextOptions<WebAppClienteDbContext> options)
            : base(options) 
        {                
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<LogradouroModel> Logradouros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new LogradouroMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
