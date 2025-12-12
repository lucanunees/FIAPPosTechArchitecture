namespace Core.Entity
{
    public class Customer : EntityBase
    {
        public required string Name { get; set; }
        public DateTime? BirthDate { get; set; }

        //Como um cliente pode ter vários pedidos, criamos uma lista de pedidos.
        public ICollection<Order> Orders { get; set; }
    }
}
