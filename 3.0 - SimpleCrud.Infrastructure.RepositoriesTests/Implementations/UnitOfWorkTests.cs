using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCrud.Common.Models;
using System;

namespace SimpleCrud.Infrastructure.Repositories.Implementations.Tests
{
    [TestClass()]
    public class UnitOfWorkTests
    {
        MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Student, StudentDTO>();
            cfg.CreateMap<StudentDTO, Student>();
        });

        StudentDTO testStudent0 = new StudentDTO()
        {
            Id = 0,
            Name = "John",
            Surname = "Doe",
            Birthday = DateTime.Parse("22-08-1997"),
            Age = 0
        };


        [TestMethod()]
        public void UnitOfWorkAddRemoveTest()
        {
            var mapper = new Mapper(config);
            Student addedStudent = null;

            using (var unitOfWork = new UnitOfWork(new SimpleCRUDContext()))
            {
                var student = mapper.Map<Student>(testStudent0);
                try
                {
                    unitOfWork.Students.Add(student);
                    addedStudent = unitOfWork.Students.Get(testStudent0.Id);
                    unitOfWork.Complete();
                }
                catch (Exception)
                {
                }
            }

            Assert.AreEqual(testStudent0, mapper.Map<StudentDTO>(addedStudent));

            using (var unitOfWork = new UnitOfWork(new SimpleCRUDContext()))
            {
                unitOfWork.Students.RemoveAll();
                unitOfWork.Complete();
            }
        }
    }
}