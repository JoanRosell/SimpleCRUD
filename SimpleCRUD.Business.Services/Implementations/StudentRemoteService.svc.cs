using SimpleCrud.Common.Models;
using SimpleCRUD.Business.Logic.Contracts;
using SimpleCRUD.Business.Logic.Implementations;
using System.Collections.Generic;
using System.ServiceModel;

namespace SimpleCRUD.Business.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class StudentRemoteService : IStudentRemoteService
    {
        IStudentService _service;

        public StudentRemoteService()
        {
            _service = new StudentService();
        }

        public void Add(StudentDTO studentData)
        {
            _service.Add(studentData);
        }

        public void Update(StudentDTO studentData)
        {
            _service.Update(studentData);
        }

        public StudentDTO Get(int id)
        {
            
            return _service.Get(id);
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            return _service.GetAll();
        }

        public void Remove(StudentDTO studentData)
        {
            _service.Remove(studentData);
        }
    }
}
