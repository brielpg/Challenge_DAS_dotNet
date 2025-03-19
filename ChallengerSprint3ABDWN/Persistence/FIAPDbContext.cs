using ABDWNSprint1.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ABDWNSprint1.Persistence
{
    public class FIAPDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public FIAPDbContext(DbContextOptions<FIAPDbContext> options) : base(options)
        {

        }

    }
}
