namespace Core.Entity
{
    public class Book : EntityBase
    {
        public required string Name { get; set; }
        public required string Publisher { get; set; }

        // Como um livro pode estar em vários pedidos, criamos uma lista de pedidos.
        public ICollection<Order> Orders { get; set; }
    }
}
