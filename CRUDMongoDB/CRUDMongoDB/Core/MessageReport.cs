using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMongoDB.Core
{
    public class MessageReport
    {
        public   bool isSuccess { get; set; }
        public string Messeage { get; set; }

        public MessageReport()
        {

        }
        public MessageReport(bool isSuccess , string Messeage)
        {
            this.isSuccess = isSuccess;
            this.Messeage = Messeage;
        }
    }
}
