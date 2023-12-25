using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewWebSite.Core.Interface
{
    public interface IUser
    {
        bool CheckCreateAdminUser();
        bool CheckPermissionForUser(string username, int permissionId);
    }   
   
}
