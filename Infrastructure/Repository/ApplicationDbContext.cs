using Core.Entity;
using Infrastructure.Repository.Configurations;
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


        //Só podera ser alterado via herança.
        //override para poder sobrescrever a implmentação padrão do método.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Se não estiver configurado, configura a conexão com o banco de dados SQL Server
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        // Esse método é usado para mapear as propriedades das entidades para as colunas do banco de dados.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ele realiza a criação das tabelas e as configurações de acordo com a EntityTypeConfiguration que adicionamo e mapeamos na classe.
            // Ao invés de colocar todas as classes, eu chamo um único método que faz isso vendo a assembly, ou seja ele vai varrer o projeto procurando todas as classes que implementam IEntityTypeConfiguration.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
