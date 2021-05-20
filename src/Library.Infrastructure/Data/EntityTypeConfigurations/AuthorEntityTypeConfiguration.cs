using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.EntityTypeConfigurations
{
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(a => a.Id);
            
            builder.Property(a => a.CreateRecordDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(a => a.LastUpdateRecordDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(a => a.Version).HasDefaultValue(1);
            
            builder.Property(a => a.FirstName).IsRequired();
            
            builder.Property(a => a.LastName).IsRequired();
        }
    }
}