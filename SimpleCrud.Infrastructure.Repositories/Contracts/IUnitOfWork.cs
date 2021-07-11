using System;

namespace SimpleCrud.Infrastructure.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }

        int Complete();
    }
}
