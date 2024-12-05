using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus.ValueObjects;
using BuberDinner.Domain.Users.ValueObjects;

namespace BuberDinner.Domain.Hosts;

public class Host : AggregateRoot<HostId, Guid>
{
    private readonly List<MenuId> _menuIds = new ();
    private readonly List<DinnerId> _dinnerIds = new ();

    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string ProfileImage { get; private set; } = default!;
    public AverageRating AverageRating { get; private set; } = default!;
    public UserId UserId { get; private set; } = default!;

    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Host() { }

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        AverageRating = AverageRating.CreateNew();
    }

    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
    {
        return new Host(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
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

    // Additional methods to manage menus and dinners can be added here
}
