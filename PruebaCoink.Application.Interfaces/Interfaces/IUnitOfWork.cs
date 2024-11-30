using System.Transactions;

namespace PruebaCoink.Application.Interfaces.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User {  get; }
        TransactionScope BeginTransaction();
    }
}
