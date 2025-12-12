using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder) 
        {
            builder.ToTable("Book");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(c => c.CreateAt).HasColumnType("DATETIME").IsRequired();
            builder.Property(c => c.Name).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(c => c.Publisher).HasColumnType("VARCHAR(100)").IsRequired();
        }
    }
}
