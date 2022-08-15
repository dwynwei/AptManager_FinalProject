using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.CreditCard
{
    /*
     * DTO For Updating Credit Card
     */
    public class UpdateCreditCardRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public string CVC { get; set; }
        public string expireDate { get; set; }

    }
}
