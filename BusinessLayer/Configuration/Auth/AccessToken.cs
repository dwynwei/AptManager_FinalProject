using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Configuration.Auth
{
    /*
     * Token Model For Authentication
     */
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }

    }
}
