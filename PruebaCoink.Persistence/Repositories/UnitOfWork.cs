using PruebaCoink.Application.Interfaces.Interfaces;
using PruebaCoink.Persistence.Context;
using System.Transactions;

namespace PruebaCoink.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository Usuario { get; }
        public IPaisesRepository Paises { get; }
        public IMunicipioRepository Municipio { get; }
        public IDepartamentoRepository Departamento { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Usuario = new UserRepository(_context);
            Paises = new PaisesRepository(_context);
            Municipio = new MunicipalityRepository(_context);
            Departamento = new DepartamentoRepository(_context);
        }

        public TransactionScope BeginTransaction()
        {
            var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            return transaction;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
