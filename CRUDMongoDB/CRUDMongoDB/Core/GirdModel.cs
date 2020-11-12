using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMongoDB.Core
{
    public class GirdModel<T> where T : class
    {
        public List<T> Data { get; set; }

        public int TotalPage { get; set; }

        public int TotalIem { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }   
    }
}
