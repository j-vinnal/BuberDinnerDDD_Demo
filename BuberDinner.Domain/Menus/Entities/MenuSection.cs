using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menus.ValueObjects;

namespace BuberDinner.Domain.Menus.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new ();

    private MenuSection() { }

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description,
        List<MenuItem> items)
        : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public static MenuSection Create(
        string name,
        string description,
        List<MenuItem> items)
    {
        return new MenuSection(
            MenuSectionId.CreateUnique(),
            name,
            description,
            items ?? new List<MenuItem>());
    }
}