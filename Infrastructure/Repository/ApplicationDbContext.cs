using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ApplicationDbContext : DbContext
    {
        // Baixamos o nuget Microsoft.EntityFrameworkCore.SqlServer ( somente no projeto Infrastructure )
        // criamos a conexão com o banco de dados SQL Server no projeto inicial.
        // passamos a connection string via construtor para o DbContext (Injeção de dependencia)
        private readonly string _connectionString;

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Configuramos as entitades no banco de dados
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
