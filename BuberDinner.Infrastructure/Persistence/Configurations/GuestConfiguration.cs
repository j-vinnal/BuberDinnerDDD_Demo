using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Users.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));

        builder.Property(g => g.FirstName).HasMaxLength(100);
        builder.Property(g => g.LastName).HasMaxLength(100);
        builder.Property(g => g.ProfileImage);

        builder.OwnsOne(g => g.AverageRating);

        builder.Property(g => g.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.OwnsMany(g => g.UpcomingDinnerIds, ud =>
        {
            ud.ToTable("GuestUpcomingDinners");
            ud.WithOwner().HasForeignKey("GuestId");
            ud.HasKey("Id");
            ud.Property(d => d.Value).HasColumnName("DinnerId").ValueGeneratedNever();
        });

        builder.OwnsMany(g => g.PastDinnerIds, pd =>
        {
            pd.ToTable("GuestPastDinners");
            pd.WithOwner().HasForeignKey("GuestId");
            pd.HasKey("Id");
            pd.Property(d => d.Value).HasColumnName("DinnerId").ValueGeneratedNever();
        });

        builder.OwnsMany(g => g.PendingDinnerIds, pd =>
        {
            pd.ToTable("GuestPendingDinners");
            pd.WithOwner().HasForeignKey("GuestId");
            pd.HasKey("Id");
            pd.Property(d => d.Value).HasColumnName("DinnerId").ValueGeneratedNever();
        });

        builder.OwnsMany(g => g.BillIds, b =>
        {
            b.ToTable("GuestBills");
            b.WithOwner().HasForeignKey("GuestId");
            b.HasKey("Id");
            b.Property(bi => bi.Value).HasColumnName("BillId").ValueGeneratedNever();
        });

        builder.OwnsMany(g => g.MenuReviewIds, mr =>
        {
            mr.ToTable("GuestMenuReviews");
            mr.WithOwner().HasForeignKey("GuestId");
            mr.HasKey("Id");
            mr.Property(mr => mr.Value).HasColumnName("MenuReviewId").ValueGeneratedNever();
        });

        builder.OwnsMany(g => g.Ratings, r =>
        {
            r.ToTable("GuestRatings");
            r.WithOwner().HasForeignKey("GuestId");
            r.HasKey("Id");
            r.Property(r => r.Id)
                .HasColumnName("RatingId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => GuestRatingId.Create(value));
            r.Property(r => r.HostId).HasConversion(id => id.Value, value => HostId.Create(value));
            r.Property(r => r.DinnerId).HasConversion(id => id.Value, value => DinnerId.Create(value));
            r.Property(r => r.Rating).HasConversion(r => r.Value, value => Rating.Create(value));
        });

        builder.Property(g => g.CreatedDateTime);
        builder.Property(g => g.UpdatedDateTime);
    }
}