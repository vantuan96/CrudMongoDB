using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMongoDB.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string  Age { get; set; }
        public string IsDelete { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
