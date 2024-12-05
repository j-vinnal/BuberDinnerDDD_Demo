using BuberDinner.Domain.Bills;
using BuberDinner.Domain.Dinners;
using BuberDinner.Domain.Guests;
using BuberDinner.Domain.Hosts;
using BuberDinner.Domain.MenuReviews;
using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Users;

using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence;

public class BuberDinnerDbContext : DbContext
{
    public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options)
    : base(options)
    {
    }

    public DbSet<Menu> Menus { get; set; } = default!;
    public DbSet<Host> Hosts { get; set; } = default!;
    public DbSet<Dinner> Dinners { get; set; } = default!;
    public DbSet<Bill> Bills { get; set; } = default!;
    public DbSet<Guest> Guests { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<MenuReview> MenuReviews { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);
    }
}