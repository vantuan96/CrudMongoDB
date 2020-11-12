using CRUDMongoDB.Core;
using CRUDMongoDB.Data.Repository.Mongo;
using CRUDMongoDB.Models;
using CRUDMongoDB.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMongoDB.Service
{
    public class StudentService : IStudent
    {
        private IStudentRepository StudentRepository;
        public StudentService(IStudentRepository StudentRepository)
        {
            this.StudentRepository = StudentRepository;
        }
        public async Task<MessageReport> Create(Student model)
        {
            return await StudentRepository.Add(model);
        }

        public Task<MessageReport> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetById(string id)
        {
            return await StudentRepository.GetOneById(id);
        }

        public Task<GirdModel< Student>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<MessageReport> Update(Student model)
        {
            throw new NotImplementedException();
        }
    }
}
