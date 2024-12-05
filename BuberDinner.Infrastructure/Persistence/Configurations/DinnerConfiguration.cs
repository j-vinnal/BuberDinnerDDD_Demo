using BuberDinner.Domain.Bills.ValueObjects;
using BuberDinner.Domain.Dinners;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class DinnerConfiguration : IEntityTypeConfiguration<Dinner>
{
    public void Configure(EntityTypeBuilder<Dinner> builder)
    {
        ConfigureDinnersTable(builder);
        ConfigureDinnerReservationsTable(builder);
    }

    private void ConfigureDinnersTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.HasKey(nameof(Dinner.Id));

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));

        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(100);
        builder.Property(x => x.StartDateTime);
        builder.Property(x => x.EndDateTime);
        builder.Property(x => x.Status);
        builder.Property(x => x.IsPublic);
        builder.Property(x => x.MaxGuests);
        builder.Property(x => x.ImageUrl);

        // Convert Price to a supported type
        builder.OwnsOne(x => x.Price, pb =>
        {
            pb.Property(p => p.Amount).HasColumnName("PriceAmount");
            pb.Property(p => p.Currency).HasColumnName("PriceCurrency").HasMaxLength(3);
        });

        // Convert Location to a supported type
        builder.OwnsOne(x => x.Location, lb =>
        {
            lb.Property(l => l.Name).HasColumnName("LocationName").HasMaxLength(100);
            lb.Property(l => l.Address).HasColumnName("LocationAddress").HasMaxLength(200);
            lb.Property(l => l.Latitude).HasColumnName("LocationLatitude");
            lb.Property(l => l.Longitude).HasColumnName("LocationLongitude");
        });

        builder.Property(x => x.MenuId)
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder.Property(x => x.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));
    }

    private void ConfigureDinnerReservationsTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.OwnsMany(x => x.Reservations, rb =>
        {
            rb.ToTable("DinnerReservations");

            rb.HasKey("Id");

            rb.Property(x => x.Id)
                .HasColumnName("ReservationId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ReservationId.Create(value));

            rb.Property(x => x.GuestCount);
            rb.Property(x => x.ArrivalDateTime);

            rb.Property(x => x.BillId)
                .HasConversion(
                    id => id!.Value,
                    value => BillId.Create(value));

            rb.Property(x => x.GuestId)
                .HasConversion(
                    id => id!.Value,
                    value => GuestId.Create(value));
        });

        builder.Metadata.FindNavigation(nameof(Dinner.Reservations))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}