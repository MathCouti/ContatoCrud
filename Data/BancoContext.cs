using Microsoft.EntityFrameworkCore;

namespace PraticaWeb
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) :base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
