using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;


namespace ETicaret.Identity
{
    public class IdentityInitializer : DropCreateDatabaseIfModelChanges<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            // Rolleri
            if (!context.Roles.Any(i => i.Name == "admin"))//admin rolu varmı
            {
                var store = new RoleStore<ApplicationRole>(context);//etkileşim için rollestore oluşturur
                var manager = new RoleManager<ApplicationRole>(store);//güncellemek ve silmek için rolle oluşturur
                var role = new ApplicationRole() { Name = "admin", Description = "admin rolü" };//admini temsil etmek için bir applicationrole oluşturur
                manager.Create(role);//create eder
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);//etkileşim için rollestore oluşturur
                var manager = new RoleManager<ApplicationRole>(store);//güncellemek ve silmek için rolle oluşturur
                var role = new ApplicationRole() { Name = "user", Description = "user rolü" }; //admini temsil etmek için bir applicationrole oluşturur
                manager.Create(role);
            }

            if (!context.Users.Any(i => i.Name == "enes"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "enes", Surname = "karadayi", UserName = "eneskaradayi", Email = "eneskaradayi@gmail.com" };

                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "admin");
                //manager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(i => i.Name == "a"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "a", Surname = "a", UserName = "aa", Email = "aa@gmail.com" };

                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "user");
            }



            base.Seed(context);
        }
    }
}