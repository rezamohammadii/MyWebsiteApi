using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewWebSite.AccessLayer.Entity
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RolePermission> Permissions { get; set; }
    }

    public class RolePermission
    {
        [Key]
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Permission Permission { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public virtual Role Role { get; set; }
    }
}
