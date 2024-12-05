using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus.Entities;
using BuberDinner.Domain.Menus.ValueObjects;
using BuberDinner.Domain.MenusReviews.ValueObjects;

namespace BuberDinner.Domain.Menus;

public class Menu : AggregateRoot<MenuId, Guid>
{
    private readonly List<MenuSection> _sections = new ();
    private readonly List<DinnerId> _dinnerIds = new ();
    private readonly List<MenuReviewId> _menuReviewIds = new ();

    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public AverageRating AverageRating { get; private set; } = default!;

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public HostId HostId { get; private set; } = default!;
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; } = default!;
    public DateTime UpdatedDateTime { get; private set; } = default!;

    private Menu() { }

    private Menu(
        MenuId menuId,
        HostId hostId,
        string name,
        string description,
        AverageRating averageRating,
        List<MenuSection> sections)
        : base(menuId)
    {
        HostId = hostId;
        Name = name;
        Description = description;
        _sections = sections;
        AverageRating = averageRating;
    }

    public static Menu Create(
        HostId hostId,
        string name,
        string description,
        List<MenuSection>? sections)
    {
        return new Menu(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            AverageRating.CreateNew(),
            sections ?? new ());
    }

    public void AddRating(Rating rating)
    {
        AverageRating.AddRating(rating);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void RemoveRating(Rating rating)
    {
        AverageRating.RemoveRating(rating);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void AddDinner(DinnerId dinnerId)
    {
        _dinnerIds.Add(dinnerId);
    }

    public void RemoveDinner(DinnerId dinnerId)
    {
        _dinnerIds.Remove(dinnerId);
    }
}