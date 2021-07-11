namespace SimpleCrud.Infrastructure.Repositories.Contracts
{
    public interface IStudentRepository : IRepository<Student>
    {
        void RemoveAll();
    }
}
