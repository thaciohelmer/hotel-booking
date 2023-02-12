using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.IdentityDocument)
                .Property(x => x.IdentityNumber);

            builder.OwnsOne(x => x.IdentityDocument)
                .Property(x => x.DocumentType);
        }
    }
}
