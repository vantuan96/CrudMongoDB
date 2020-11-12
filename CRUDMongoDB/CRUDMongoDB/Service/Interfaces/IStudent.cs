using CRUDMongoDB.Core;
using CRUDMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMongoDB.Service.Interfaces
{
    public interface IStudent
    {
        Task<GirdModel<Student>> GetList();
        Task<Student> GetById(string id);
        Task<MessageReport> Create(Student model);
        Task<MessageReport> Update(Student model);
        Task<MessageReport> Delete(string id);
    }
}
