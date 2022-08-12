using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.CreditCard
{
    public class CreateCreditCardRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public string CVC { get; set; }
        public string expireDate { get; set; }
    }
}
