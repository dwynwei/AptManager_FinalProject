using BusinessLayer.Configuration.Auth;
using BusinessLayer.Configuration.CommandResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        CommandResponse VerifyPassword(string email, string password);
        AccessToken Login(string nationalityId, string password);
    }
}
