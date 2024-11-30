using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menus;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly BuberDinnerDbContext _dbContext;

    public MenuRepository(BuberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    void IMenuRepository.Add(Menu menu)
    {
        _dbContext.Menus.Add(menu);
        _dbContext.SaveChanges();
    }
}