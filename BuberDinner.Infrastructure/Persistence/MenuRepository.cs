using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menus;

namespace BuberDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();

    void IMenuRepository.Add(Menu menu)
    {
        _menus.Add(menu);
    }
}