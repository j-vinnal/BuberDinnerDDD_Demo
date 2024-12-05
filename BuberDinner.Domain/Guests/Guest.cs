using BuberDinner.Domain.Bills.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Guestss.Entities;
using BuberDinner.Domain.MenuReviews.ValueObjects;
using BuberDinner.Domain.Users.ValueObjects;

namespace BuberDinner.Domain.Guests;

public class Guest : AggregateRoot<GuestId, Guid>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new ();
    private readonly List<DinnerId> _pastDinnerIds = new ();
    private readonly List<DinnerId> _pendingDinnerIds = new ();
    private readonly List<BillId> _billIds = new ();
    private readonly List<MenuReviewId> _menuReviewIds = new ();
    private readonly List<GuestRating> _ratings = new ();

    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string ProfileImage { get; private set; } = default!;
    public AverageRating AverageRating { get; private set; } = default!;
    public UserId UserId { get; private set; } = default!;

    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<GuestRating> Ratings => _ratings.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Guest() { }

    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        AverageRating = AverageRating.CreateNew();
    }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
    {
        return new Guest(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddRating(GuestRating rating)
    {
        _ratings.Add(rating);
        AverageRating.AddRating(rating.Rating);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void RemoveRating(GuestRating rating)
    {
        if (_ratings.Remove(rating))
        {
            AverageRating.RemoveRating(rating.Rating);
            UpdatedDateTime = DateTime.UtcNow;
        }
    }
}
