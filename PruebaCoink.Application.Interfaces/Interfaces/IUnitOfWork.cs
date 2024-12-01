using System.Transactions;

namespace PruebaCoink.Application.Interfaces.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IMunicipioRepository Municipio { get; }
        IDepartamentoRepository Departamento { get; }
        TransactionScope BeginTransaction();
    }
}
