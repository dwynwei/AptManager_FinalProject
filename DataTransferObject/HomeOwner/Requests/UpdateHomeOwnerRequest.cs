using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.User
{
    /*
     * DTO For Updating a Home Owner Information
     */
    public class UpdateHomeOwnerRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalityId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CarPlateId { get; set; }
        public decimal Bill { get; set; }
    }
}
