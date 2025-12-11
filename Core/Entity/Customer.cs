namespace Core.Entity
{
    public class Customer : EntityBase
    {
        public required string Name { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
