using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menus.ValueObjects;

namespace BuberDinner.Domain.Menus.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    private MenuItem(MenuItemId menuItemId, string name, string description) 
        : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    private MenuItem() { }
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;

    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }
}
