using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ETicaret.Identity
{
    //Evet, bu kod bir uygulama rolü nesnesi için bir sınıf tanımı sağlar.Bu sınıf, bir uygulama rolünün adını ve açıklamasını temsil eder.
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
        public ApplicationRole()
        {
        }
        public ApplicationRole(string rolename, string description)
        {
            this.Description = description;
        }
    }
}