using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.LastName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.DateBirth)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(30);

            builder.Property(p => p.Address)
                .HasMaxLength(30);

            builder.Property(p => p.Age);

            builder.Property(p => p.CreateBy)
                .HasMaxLength(10);

            builder.Property(p => p.LastModifiedBy)
                .HasMaxLength(10);
        }
    }
}
