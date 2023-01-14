using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewWebSite.AccessLayer.Entity
{
    public class Users
    {
        [Key]
        public ulong Id { get; set; }
        public Guid Uid { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Email { get; set; }
        public string? Pwd { get; set; }
        public int Age { get; set; }
        public long NationalCode { get; set; }
        public ulong CardNumber { get; set; }
        public long Moblile { get; set; }
        public DateTime CreateAccount { get; set; }
        public DateTime LastSeen { get; set; }
        public bool Activate { get; set; }
        public bool IsNotification { get; set; }
        public AccountStatus Status { get; set; }


    }

    public enum AccountStatus
    {
        ActiveMobile = 1,
        ActiveEmail = 2,
        AdminReview = 3,
        FullActive = 4
    }
}
