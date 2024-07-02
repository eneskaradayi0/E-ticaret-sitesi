using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ETicaret.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}


//Evet, bu kod bir uygulama kullanıcısı nesnesi için bir sınıf tanımı sağlar. Bu sınıf, bir uygulama kullanıcısının adını, soyadını ve diğer özelliklerini temsil eder