using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIB.PhoneBook.Infrastructure.Data.Configuration
{
    using Domain;
    [ExcludeFromCodeCoverage]
    internal class PhoneBookEntryConfiguration : IEntityTypeConfiguration<PhoneBookEntry>
    {
        public void Configure(EntityTypeBuilder<PhoneBookEntry> builder)
        {
            builder.ToTable("PhoneBookEntry")
                .HasKey(o => o.Name);

            builder.HasIndex(e => e.Name).IsUnique();

            builder.Property(p => p.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property<DateTime>("DateCreated")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

        }
    }
}
