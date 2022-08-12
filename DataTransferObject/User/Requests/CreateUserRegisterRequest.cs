using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.User.Requests
{
    public class CreateUserRegisterRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalityId { get; set; }
        public string UserPassword { get; set; }
        public string VerifyPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CarPlateId { get; set; }
        public UserRole Role { get; set; }
    }
}
