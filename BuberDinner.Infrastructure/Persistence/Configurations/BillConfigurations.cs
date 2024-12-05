using BuberDinner.Domain.Bills;
using BuberDinner.Domain.Bills.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bills");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BillId.Create(value));

        builder.Property(b => b.DinnerId)
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));

        builder.Property(b => b.GuestId)
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));

        builder.Property(b => b.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.OwnsOne(b => b.Price, p =>
        {
            p.Property(pp => pp.Amount).HasColumnName("PriceAmount");
            p.Property(pp => pp.Currency).HasColumnName("PriceCurrency");
        });

        builder.Property(b => b.CreatedDateTime);
        builder.Property(b => b.UpdatedDateTime);
    }
}