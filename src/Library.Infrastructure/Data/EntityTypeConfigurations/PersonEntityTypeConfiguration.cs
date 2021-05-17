using Library.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.EntityTypeConfigurations
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People");
            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.FirstName).IsRequired();
            
            builder.Property(p => p.LastName).IsRequired();

            builder
                .HasMany(p => p.Books)
                .WithMany(b => b.Readers)
                .UsingEntity<LibraryCard>(
                    j => j
                        .HasOne(lr => lr.Book)
                        .WithMany()
                        .HasForeignKey(lr => lr.PersonId),
                    j => j
                        .HasOne(lr => lr.Person)
                        .WithMany()
                        .HasForeignKey(lr => lr.PersonId),
                    j =>
                    {
                        j.HasKey(lr => new { lr.BookId, lr.PersonId });
                        j.Property(lr => lr.TimeGetBook).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    });
        }
    }
}