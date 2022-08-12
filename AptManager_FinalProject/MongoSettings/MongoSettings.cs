using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MongoSettings
{
    public class MongoSettings : IMongoSettings
    {
        public string Collection { get; set; }
        public string Connection { get; set; }
        public string DatabaseName { get; set; }
    }
}
