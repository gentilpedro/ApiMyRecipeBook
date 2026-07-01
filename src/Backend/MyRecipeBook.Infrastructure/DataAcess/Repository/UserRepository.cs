using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repository.User;

namespace MyRecipeBook.Infrastructure.DataAcess.Repository;

internal sealed class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
{    
    private readonly MyRecipeBookDbContext _context;
    public UserRepository(MyRecipeBookDbContext context)
    {
        _context = context;
    }

    public async Task Add(User user) => await _context.Users.AddAsync(user);



    public async Task<bool> ExistActiveUserEmail(string email) => await _context.Users.AnyAsync(user => user.Active 
                                                                                                    && user.Email.Equals(email));
}
