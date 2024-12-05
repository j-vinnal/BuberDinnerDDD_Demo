using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinners.Enums;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus.ValueObjects;

namespace BuberDinner.Domain.Dinners;

public class Dinner : AggregateRoot<DinnerId, Guid>
{
    private readonly List<Reservation> _reservations = new ();

    public string Name { get; private set; } = default!;

    public string Description { get; private set; } = default!;
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }

    public DinnerStatus Status { get; private set; }

    public bool IsPublic { get; private set; }
    public int MaxGuests { get; private set; }
    public Price Price { get; private set; } = default!;

    public HostId HostId { get; private set; } = default!;
    public MenuId MenuId { get; private set; } = default!;
    public string ImageUrl { get; private set; } = default!;

    public Location Location { get; private set; } = default!;

    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Dinner() { }

    private Dinner(
       DinnerId dinnerId,
       string name,
       string description,
       DateTime startDateTime,
       DateTime endDateTime,
       DinnerStatus status,
       bool isPublic,
       int maxGuests,
       Price price,
       HostId hostId,
       MenuId menuId,
       string imageUrl,
       Location location,
       DateTime createdDateTime,
       DateTime updatedDateTime)
       : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location)
    {
        return new Dinner(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            DinnerStatus.Upcoming,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
