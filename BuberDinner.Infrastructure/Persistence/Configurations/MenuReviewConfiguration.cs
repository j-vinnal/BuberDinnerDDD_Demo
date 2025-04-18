using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.MenuReviews;
using BuberDinner.Domain.MenuReviews.ValueObjects;
using BuberDinner.Domain.Menus.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class MenuReviewConfiguration : IEntityTypeConfiguration<MenuReview>
{
    public void Configure(EntityTypeBuilder<MenuReview> builder)
    {
        builder.ToTable("MenuReviews");

        builder.HasKey(mr => mr.Id);

        builder.Property(mr => mr.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuReviewId.Create(value));

        builder.Property(mr => mr.Rating)
            .HasConversion(
                rating => rating.Value,
                value => Rating.Create(value));

        builder.Property(mr => mr.Comment)
            .HasMaxLength(500);

        builder.Property(mr => mr.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.Property(mr => mr.MenuId)
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder.Property(mr => mr.GuestId)
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));

        builder.Property(mr => mr.DinnerId)
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));

        builder.Property(mr => mr.CreatedDateTime);
        builder.Property(mr => mr.UpdatedDateTime);
    }
}