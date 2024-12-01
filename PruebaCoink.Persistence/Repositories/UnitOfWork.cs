using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Persistence.Context;
using System.Transactions;

namespace PruebaCoink.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository User { get; }
        public IMunicipioRepository Municipio { get; }
        public IDepartamentoRepository Departamento { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            Municipio = new MunicipalityRepository(_context);
            Departamento = new DepartamentoRepository(_context);
        }

        public TransactionScope BeginTransaction()
        {
            TransactionScope transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            return transaction;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
