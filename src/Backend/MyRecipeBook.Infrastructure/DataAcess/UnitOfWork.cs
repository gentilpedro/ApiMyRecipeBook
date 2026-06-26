using MyrecipeBook.Domain.Repository;

namespace MyRecipeBook.Infrastructure.DataAcess;

internal class UnitOfWork : IUnitOfWork 
{
    private readonly MyRecipeBookDbContext _context;
    public UnitOfWork(MyRecipeBookDbContext context)
    {
        _context = context;
    }

    public async Task Commit() => await _context.SaveChangesAsync();
    
}