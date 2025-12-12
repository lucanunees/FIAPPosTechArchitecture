namespace Core.Entity
{
    public class Order : EntityBase
    {
        public int  CustomerId { get; set; }
        public int BookId { get; set; }

        //Propriedades de naveção para o EF poder gerar os relacionamentos.(Foreign Keys).
        public Customer Customer { get; set; }
        public Book Book { get; set; }
    }
}
