using AutoMapper;
using SimpleCrud.Common.Models;
using SimpleCrud.Infrastructure.Repositories;
using SimpleCrud.Infrastructure.Repositories.Implementations;
using SimpleCRUD.Business.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimpleCRUD.Business.Logic.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Student, StudentDTO>();
            cfg.CreateMap<StudentDTO, Student>();
        }).CreateMapper();

        public void Add(StudentDTO studentData)
        {
            studentData.Age = CalculateAge(studentData.Birthday);
            using (var unitOfWork = new UnitOfWork(new SimpleCRUDContext()))
            {
                unitOfWork.Students.Add(_mapper.Map<Student>(studentData));
                unitOfWork.Complete();
            }
        }

        private int CalculateAge(DateTime birthday)
        {
            var today = DateTime.Today;
            var age = today.Year - birthday.Year;
            if (birthday.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        public StudentDTO Get(int id)
        {
            Student student;
            using (var unitOfWork = new UnitOfWork(new SimpleCRUDContext()))
            {
                student = unitOfWork.Students.Get(id);
                unitOfWork.Complete();
            }

            return _mapper.Map<StudentDTO>(student);
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            IEnumerable<Student> studentsFound = null;
            using (var unitOfWork = new UnitOfWork(new SimpleCRUDContext()))
            {
                studentsFound = unitOfWork.Students.GetAll();
                unitOfWork.Complete();
            }

            return _mapper.Map<IEnumerable<StudentDTO>>(studentsFound);
        }

        public void Remove(StudentDTO studentData)
        {
            using (var unitOfWork = new UnitOfWork(new SimpleCRUDContext()))
            {
                unitOfWork.Students.Remove(_mapper.Map<Student>(studentData));
                unitOfWork.Complete();
            }
        }

        public void Update(StudentDTO studentData)
        {
            using (var unitOfWork = new UnitOfWork(new SimpleCRUDContext()))
            {
                Student student = unitOfWork.Students.Get(studentData.Id);
                student.Name = studentData.Name;
                student.Surname = studentData.Surname;
                student.Birthday = studentData.Birthday;
                student.Age = CalculateAge(student.Birthday);
                unitOfWork.Complete();
            }
        }
    }
}
