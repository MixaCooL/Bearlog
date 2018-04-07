using System;
using System.Collections.Generic;

namespace Bearlog.Web.Models
{
    public class UserModel
    {
        public virtual Guid Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string[] Roles { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual bool IsBanned { get; set; }
        public virtual bool IsActive { get; set; }
    }
}