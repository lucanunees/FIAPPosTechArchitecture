namespace Core.Entity
{
    public class Book : EntityBase
    {
        public required string Name { get; set; }
        public required string Publisher { get; set; }
    }
}
