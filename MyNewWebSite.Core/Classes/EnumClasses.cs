using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewWebSite.Core.Classes
{
    public  enum UserRoles
    {
        Admin = 1,
        Manager = 2,
        User = 3
    }
    public enum AllPermission
    {
        None = 0,
        Full  = 1,
        Add_User = 2,
        Delete_User = 3
    }   
}
