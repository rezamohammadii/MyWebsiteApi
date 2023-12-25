using MyNewWebSite.AccessLayer.Context;
using MyNewWebSite.AccessLayer.Entity;
using MyNewWebSite.Core.CodeFactory;
using MyNewWebSite.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewWebSite.Core.Services
{
    public class UserService : IUser
    {
        private readonly MyDatabaseContext _db;
        public UserService(MyDatabaseContext _db)
        {
            this._db = _db;
        }
        public bool CheckCreateAdminUser()
        {
            if (_db.Users.Where(u => u.RoleId == (int)UserRoles.Admin).Any())
            {
                return true;
            }
            else
            {
                User user = new User()
                {
                    RoleId = (int)UserRoles.Admin,
                    Email = "admin@agent47.ir",

                }
            }
        }
    }
}
