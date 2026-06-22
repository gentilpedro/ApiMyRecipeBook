using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repository.User;

namespace MyRecipeBook.Infrastructure.DataAcess.Repository;

internal sealed class UserRepository : IUserWriteOnlyRepository
{    
    private readonly MyRecipeBookDbContext _context;
    public UserRepository(MyRecipeBookDbContext context)
    {
        _context = context;
    }

    public async Task Add(User user) => await _context.Users.AddAsync(user);
    
}
