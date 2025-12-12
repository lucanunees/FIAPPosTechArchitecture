using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(c => c.CreateAt).HasColumnType("DATETIME").IsRequired();
            builder.Property(c => c.CustomerId).HasColumnType("INT").IsRequired();
            builder.Property(c => c.BookId).HasColumnType("INT").IsRequired();

            //Um cliente com vários pedidos e a chave estrangeira é CustomerId (Id).
            builder.HasOne(c => c.Customer)
                   .WithMany(o => o.Orders)
                   .HasPrincipalKey(o => o.Id);

            builder.HasOne(c => c.Book)
                   .WithMany(o => o.Orders)
                   .HasPrincipalKey(o => o.Id);
        }
    }
}
