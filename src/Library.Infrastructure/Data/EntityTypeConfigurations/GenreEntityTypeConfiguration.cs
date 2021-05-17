using Library.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.EntityTypeConfigurations
{
    public class GenreEntityTypeConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");
            builder.HasKey(g => g.Id);
            
            builder.Property(g => g.Name).IsRequired();
            
            builder
                .HasMany(g => g.Books)
                .WithMany(b => b.Genres)
                .UsingEntity(x => x.ToTable("BookGenreLink"));
        }
    }
}