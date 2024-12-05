using BuberDinner.Domain.Dinners;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Menus.Entities;
using BuberDinner.Domain.Menus.ValueObjects;
using BuberDinner.Domain.MenuReviews.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, mri =>
        {
            mri.ToTable("MenuReviewIds");

            mri.WithOwner().HasForeignKey("MenuId");

            mri.HasKey(nameof(MenuReviewId.Value));

            mri.Property(x => x.Value)
                .HasColumnName("ReviewId")
                .ValueGeneratedNever();
        });

        // readonly navigation property
        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, dib =>
        {
            dib.ToTable("MenuDinnerIds");

            dib.WithOwner().HasForeignKey("MenuId");

            dib.HasKey(nameof(Dinner.Id));

            dib.Property(x => x.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
        });

        // readonly navigation property
        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Sections, msb =>
        {
            msb.ToTable("MenuSections");

            msb.WithOwner().HasForeignKey("MenuId");

            msb.HasKey("Id", "MenuId");

            msb.Property(m => m.Id)
                .HasColumnName("MenuSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value));

            msb.Property(m => m.Name)
                .HasMaxLength(100);

            msb.Property(m => m.Description)
                .HasMaxLength(100);

            msb.OwnsMany(m => m.Items, msib =>
            {
                msib.ToTable("MenuItems");

                msib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                msib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

                msib.Property(m => m.Id)
                    .HasColumnName("MenuItemId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value));

                msib.Property(m => m.Name)
                    .HasMaxLength(100);

                msib.Property(m => m.Description)
                    .HasMaxLength(100);
            });

            msb.Navigation(s => s.Items).Metadata.SetField("_items");
            msb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
        .HasConversion(
            id => id.Value,
            value => MenuId.Create(value));

        builder.Property(m => m.Name)
            .HasMaxLength(100);

        builder.Property(m => m.Description)
            .HasMaxLength(100);

        builder.OwnsOne(m => m.AverageRating);

        builder.Property(m => m.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));
    }
}