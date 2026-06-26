namespace MyrecipeBook.Domain.Repository
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}