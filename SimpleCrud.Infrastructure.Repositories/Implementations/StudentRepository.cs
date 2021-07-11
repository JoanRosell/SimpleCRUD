using SimpleCrud.Infrastructure.Repositories.Contracts;

namespace SimpleCrud.Infrastructure.Repositories.Implementations
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(SimpleCRUDContext context) : base(context) { }

        public SimpleCRUDContext SimpleCRUDContext
        {
            get { return Context as SimpleCRUDContext; }
        }

        public void RemoveAll()
        {
            SimpleCRUDContext.Database.ExecuteSqlCommand("DELETE FROM dbo.Students");
        }
    }
}
