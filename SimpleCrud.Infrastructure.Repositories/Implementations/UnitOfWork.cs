using SimpleCrud.Infrastructure.Repositories.Contracts;

namespace SimpleCrud.Infrastructure.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SimpleCRUDContext _context;

        public IStudentRepository Students { get; private set; }

        public UnitOfWork(SimpleCRUDContext context)
        {
            _context = context;
            Students = new StudentRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
