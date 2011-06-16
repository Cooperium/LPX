using System.Data.Entity;
using L.PX.Core;

namespace L.PX.Models
{
    public class LeilaoModelContext : DbContext
    { 
        public DbSet<Leilao>NumerodeLotes { get; set; } 
        public DbSet<Participante> Participante { get; set; }
        public DbSet<Leilao> ValorInicial { get; set; }
        public DbSet<User> Empresa { get; set; }
        public DbSet<Leilao> Leilaos { get; set; }
    }
}
