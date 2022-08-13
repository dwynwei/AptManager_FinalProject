using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.User.Requests
{
    public class DeleteUserRequest
    {
        public int Id { get; set; }
        public string NationalityId { get; set; }
    }
}
