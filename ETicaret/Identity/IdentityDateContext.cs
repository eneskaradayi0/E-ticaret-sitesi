using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ETicaret.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("dataConnection")
        {

        }



    }
}
//Evet, bu kod bir kimlik veri bağlamı sınıfı tanımı sağlar. Bu sınıf, bir veritabanı bağlantısını ve kimlik tablolarına erişim için kullanılan nesneleri temsil eder.