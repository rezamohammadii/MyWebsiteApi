using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNewWebSite.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyNewWebSite.Core.Classes
{
    public class HasPermissionAttribute : IAuthorizationRequirement
    {
        public AllPermission permission {  get;}
        public HasPermissionAttribute(AllPermission permission)
        {
            this.permission = permission;
        }
    }
    abstract public class PermissionHandler : AuthorizationHandler<HasPermissionAttribute>
    {
        private readonly IUser user;
        public PermissionHandler(IUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            this.user = user;
        }

        protected override void Handle(AuthorizationHandlerContext context, HasPermissionAttribute hasPermission)
        {
            if (context.User == null)
            {
                return;
            }
            var has_Permission = user.CheckPermissionForUser(context.User.Identity.Name, 1);
            if (has_Permission)
            {
                context.Succeed(hasPermission);
            }
        }
    }

}
