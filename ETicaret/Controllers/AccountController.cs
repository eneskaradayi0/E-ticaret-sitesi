using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.Entity;
using ETicaret.Identity;
using ETicaret.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace ETicaret.Controllers
{
    //Bu kod, kullanıcı kimlik doğrulaması ve yetkilendirmesini işleyen bir web uygulamasında kullanılan bir kontrolör sınıfıdır.

    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        //özelliğine atar
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager; //AccountController sınıfına, kullanıcı ve rol yönetimini gerçekleştirmek için

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            _userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            _roleManager = new RoleManager<ApplicationRole>(roleStore);

        }

        [Authorize] /*yalnızca kimliği doğrulanmış kullanıcıların erişebileceğini belirtir*/
        public ActionResult Index()//kullanıcının tüm siparişlerini veritabanından alır ve bunları bir View nesnesi ile döndürür.
        {
            var username = User.Identity.Name;
            var orders = db.Orders
                .Where(i => i.Username == username)//eşleşen kayıtlara filtreler.
                .Select(i => new UserOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    Total = i.Total
                }).OrderByDescending(i => i.OrderDate).ToList();//azalan şekilde sıralar

            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            //OrderDetailsModel adlı bir nesneyi döndürür.Bu nesne, bir siparişin ayrıntılarını içerir.
           var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Sehir = i.Sehir,
                    Semt = i.Semt,
                    Mahalle = i.Mahalle,
                    PostaKodu = i.PostaKodu,
                    Orderlines = i.Orderlines.Select(a => new OrderLineModel()//orders listesini, kullanıcı adını eşleşen kayıtlara filtreler.
                    {
                        //ayrıntılar
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name.Length > 50 ? a.Product.Name.Substring(0, 47) + "..." : a.Product.Name,
                        Image = a.Product.Image,
                        Quantity = a.Quantity,
                        Price = a.Price
                    }).ToList()
                }).FirstOrDefault();//eğer içi boşssa null döner ve hata vermez

            return View(entity);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//kimlik doğrulama
        public ActionResult Register(Register model)
        {
            //register modelini al ve indexe yöndendirir
            if (ModelState.IsValid)
            {
                //Kayıt işlemleri

                var user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = _userManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //kullanıcı oluştu ve kullanıcıyı bir role atayabilirsiniz.eğer geçerli ise logine yönlendirir.
                    if (_roleManager.RoleExists("user"))
                    {
                        _userManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    //hata mesajına yönlendirir.
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı  oluşturma hatası.");
                }

            }

            return View(model);
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//güvenlik
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)//model doğrulamasının geçerli olup olmadığını kontrol eder. 
            {
                //Login işlemleri
                var user = _userManager.Find(model.UserName, model.Password);

                if (user != null)
                {
                    // varolan kullanıcıyı sisteme dahil et.
                    // ApplicationCookie oluşturup sisteme bırak.kullanıcıları kimlik doğrulamak ve yetkilendirilmek için kullandığı bir çerezdir.

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = _userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);
                    //geri dönder kullanıcı sayfasına
                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    var userroles = user.Roles.First();
                    var asd = userroles.RoleId.ToString();

                    if (asd == "6008ee43-25ab-4f49-8e9f-0383c2af7733")
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            //Kullanıcının oturumunu kapat
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            Session.Clear();
            //girişe yönlendir
            return RedirectToAction("Index", "Home");
        }

    }
}

