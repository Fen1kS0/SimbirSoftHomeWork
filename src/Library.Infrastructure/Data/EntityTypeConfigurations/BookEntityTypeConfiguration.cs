using Library.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.EntityTypeConfigurations
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.Id);
            
            builder.Property(b => b.Name).IsRequired();

            builder
                .HasOne(b => b.Author)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.AuthorId)
                .IsRequired();
        }
    }
}