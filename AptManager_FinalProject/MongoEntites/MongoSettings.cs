using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MongoEntites
{
    /*
     * Mongo Connection Settings
     * Look at "appsettings.json" for more information
     */
    public class MongoSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; } = nameof(CreditCard);
    }
}
