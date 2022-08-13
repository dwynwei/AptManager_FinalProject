using BusinessLayer.Configuration.CommandResponse;
using DataTransferObject.User.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        public CommandResponse Register(CreateUserRegisterRequest request);
    }
}
