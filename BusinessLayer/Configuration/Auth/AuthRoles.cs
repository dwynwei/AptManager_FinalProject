using Microsoft.AspNetCore.Authorization;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Configuration.Auth
{
    /*
     * Custom Authorize Attribute Setting
     */
    public class AuthRoles: AuthorizeAttribute
    {
        private UserRole roles;
        public UserRole Roles
        {
            get
            {
                return roles;
            }
            set
            {
                roles = value; base.Roles = value.ToString();
            }
        }
    }
}
