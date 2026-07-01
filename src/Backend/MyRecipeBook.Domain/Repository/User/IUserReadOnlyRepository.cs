namespace MyRecipeBook.Domain.Repository.User;

public interface IUserReadOnlyRepository
{
    Task<bool> ExistActiveUserEmail(string email);
}