using CRUDMongoDB.Data.Infrastructure;
using CRUDMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMongoDB.Data.Repository.Mongo
{
    public interface IStudentRepository : IMongoDBRepository<Student>
    {
    }
    public class StudentRepository : MongoRepository<Student>, IStudentRepository
    {

    }
}
