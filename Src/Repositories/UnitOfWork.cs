using user_microservice.Src.Data;
using user_microservice.Src.Repositories.Interfaces;

namespace user_microservice.Src.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISubjectsRepository _subjectsRepository = null!;
        //TODO: poner los repository que faltan

        private readonly DataContext _context;
        private bool _disposed = false;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public ISubjectsRepository SubjectsRepository
        {
            get
            {
                _subjectsRepository ??= new SubjectsRepository(_context);

                return _subjectsRepository;
            }
        }

        //TODO: poner los repository que faltan


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}