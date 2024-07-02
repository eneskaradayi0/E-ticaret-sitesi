using ETicaret.Entity;
using ETicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();

        // GET: Order
        public ActionResult Index()//tüm hepsini seçer
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()//her siparişi adminordermodel dönüştürür.dborderden tüm siparişlerin hepsini seçer
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.Orderlines.Count
            }).OrderByDescending(i => i.OrderDate).ToList();//tarihe göre sıralar ve listeye dönüştürür

            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)//dborderde aynı olan siparişleri seçer
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    UserName = i.Username,
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
                    Orderlines = i.Orderlines.Select(a => new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name.Length > 50 ? a.Product.Name.Substring(0, 47) + "..." : a.Product.Name,
                        Image = a.Product.Image,
                        Quantity = a.Quantity,
                        Price = a.Price
                    }).ToList()
                }).FirstOrDefault();

            return View(entity);
        }

        public ActionResult UpdateOrderState(int OrderId, EnumOrderState OrderState)//siparişi günceller//orderıd güncellenecek ürünün ıd//orderstate yeni sipariş durumu
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);//db.Orders` koleksiyonundan orderId`esşit olan siparişi seçer.

            if (order != null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();

                TempData["message"] = "Bilgileriniz Kayıt Edildi";//kullanıcıya mesaj göndeririz

                return RedirectToAction("Details", new { id = OrderId });//tamamlanan sipaişe yönlendirir
            }

            return RedirectToAction("Index");//sipariş yoksa
        }
    }
}