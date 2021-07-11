using SimpleCrud.Common.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace SimpleCRUD.Business.Services
{
    [ServiceContract]
    public interface IStudentRemoteService
    {
        [OperationContract]
        StudentDTO Get(int id);

        [OperationContract]
        IEnumerable<StudentDTO> GetAll();

        [OperationContract]
        void Add(StudentDTO studentData);

        [OperationContract]
        void Update(StudentDTO studentData);

        [OperationContract]
        void Remove(StudentDTO studentData);
    }
}
