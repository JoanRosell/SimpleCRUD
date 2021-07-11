using SimpleCrud.Common.Models;
using System.Collections.Generic;

namespace SimpleCRUD.Business.Logic.Contracts
{
    public interface IStudentService
    {
        StudentDTO Get(int id);

        IEnumerable<StudentDTO> GetAll();

        void Add(StudentDTO studentData);

        void Update(StudentDTO studentData);

        void Remove(StudentDTO studentData);
    }
}
