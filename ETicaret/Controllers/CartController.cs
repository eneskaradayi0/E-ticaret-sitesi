using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.Entity;
using ETicaret.Models;

namespace ETicaret.Controllers
{
    public class CartController : Controller
    {
        //veri tabanına bağlanır
        private DataContext db = new DataContext();
        // sepeti görüntüler ve kullanıcıdan sepeti alır
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int Id)
        {
            //ürünü bul sepete ekle
            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }

            return RedirectToAction("Index");//indexe gönder
        }

        public ActionResult RemoveFromCart(int Id)//öge kaldırmaya yarar
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);//db ürünü bul

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }

            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];

            if (cart == null)//sepet içi boşsa new sepet aç
            {
                cart = new Cart();
                Session["Cart"] = cart;//sanal bir alışveriş sepeti
            }
            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();//kullanıcı sepetini al

            if (cart.CartLines.Count == 0)//sepet boşmu bak
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)//model kısmı geçerli mi
            {
                SaveOrder(cart, entity);//kaydet
                cart.Clear();
                return View("Completed");//tamlandıya gönder
            }
            else
            {
                return View(entity);
            }
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)//order oluşturulur, kaydelilir,bilgiler atanırr
        {
            var order = new Order();

            order.OrderNumber = "A" + (new Random()).Next(11111, 99999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Bekleniyor;
            order.Username = User.Identity.Name;

            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;

            order.Orderlines = new List<OrderLine>();//sipariş kaydeilir.depolanır

            foreach (var pr in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Quantity * pr.Product.Price;
                orderline.ProductId = pr.Product.Id;

                order.Orderlines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();//değişikler eklenir
        }
    }
}